using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Data;
using WebProject.Server.Models;
using WebProject.Shared;


namespace WebProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    { 
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            return Ok(await _context.Reservations.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reserv)
        {
            _context.Reservations.Add(reserv);
            await _context.SaveChangesAsync();
            return Ok(await _context.Reservations.ToListAsync());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(h => h.Id == id);
            if (reservation == null)
                return NotFound("Reservation was not found");

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return Ok(await _context.Reservations.ToListAsync());
        }
    }
}
