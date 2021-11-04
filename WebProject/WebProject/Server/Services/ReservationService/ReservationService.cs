using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<List<ReservationGetDTO>> GetReservations()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return Mapper.Map(reservations, new List<ReservationGetDTO>());
        }

        public async Task CreateReservation(ReservationGetDTO reservationDTO)
        {
            _context.Reservations.Add(Mapper.Map(reservationDTO, new Reservation()));
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(h => h.Id == id);
            if (reservation != null)
                _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
    }
}
