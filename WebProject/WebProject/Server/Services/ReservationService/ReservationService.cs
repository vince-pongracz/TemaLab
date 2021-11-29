using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Controllers;
using WebProject.Server.Data;
using WebProject.Server.Models;
using WebProject.Server.Services;
using WebProject.Shared;


namespace WebProject.Server.Services.ReservationService
{
    public class ReservationService : IReservationService
    {

        private readonly ApplicationDbContext _context;

        [Inject]
        public IMapper Mapper { get; set; }

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MapperConfigService())));
        }
        public async Task<List<ReservationGetDTO>> GetReservations(string userID)
        {
            var reservations = await _context.Reservations
                .Where(x => x.ApplicationUserId == userID)
                .OrderByDescending(x => x.ToDate)
                .ToListAsync();
            return Mapper.Map(reservations, new List<ReservationGetDTO>());
        }

        public async Task CreateReservation(ReservationGetDTO reservationDTO)
        {
            if (IsTheReservationCorrect(reservationDTO))
            {
                _context.Reservations.Add(Mapper.Map(reservationDTO, new Reservation()));
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Reservation> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(h => h.Id == id);
            if (reservation != null && CanBeDeleted(reservation))
                _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public bool IsTheReservationCorrect(ReservationGetDTO reservation)
        {
            bool result = true;
            if (reservation.FromDate >= reservation.ToDate)
                result = false;
            else if (reservation.FromDate <= DateTime.Now)
                result = false;
            else if (reservation.Price <= 0)
                result = false;
            return result;
        }

        public bool CanBeDeleted(Reservation reserv)
        {
            DateTime date = reserv.FromDate;
            if (date.AddDays(-2) < DateTime.Now)
                return false;
            else
                return true;
        }

        private bool IsInThePast(Reservation reservation)
        {
            if (reservation.ToDate < DateTime.Now) return true;
            else return false;
        }

        public async Task<List<ReservationGetDTO>> GetIncomingBookings(string actualLoggedInUserId)
        {
            var probableShipIds = _context.Ships.Where(x => x.OwnerId == actualLoggedInUserId).Select(x => x.Id);

            var probableReservations = _context.Reservations
                .Where(x => probableShipIds.Contains(x.ShipId))
                .Where(x => CanBeDeleted(x))
                .Where(x => !IsInThePast(x));

            return Mapper.Map(await probableReservations.ToListAsync(), new List<ReservationGetDTO>());
        }
    }
}
