using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Data;
using WebProject.Server.Models;
using WebProject.Server.Services;
using WebProject.Shared;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        [Inject]
        public IMapper Mapper { get; set; }

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MapperConfig())));
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return Ok(Mapper.Map(reservations, new List<ReservationGetDTO>()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(ReservationGetDTO reservationDTO)
        {
            _context.Reservations.Add(Mapper.Map(reservationDTO,new Reservation()));
            await _context.SaveChangesAsync();

            var reservations = await _context.Reservations.ToListAsync();
            return Ok(Mapper.Map(reservations, new List<ReservationGetDTO>()));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(h => h.Id == id);
            if (reservation == null)
                return NotFound("Reservation was not found");

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            var reservations = await _context.Reservations.ToListAsync();
            return Ok(Mapper.Map(reservations, new List<ReservationGetDTO>()));
        }
    }
}
