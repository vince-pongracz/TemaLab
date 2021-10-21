using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;


namespace WebProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        static List<ReservationDTO> reservations = new List<ReservationDTO>
        {
            new ReservationDTO { Id = 1, FromDate = new DateTime(2021,10,16), PersonId = 2, Price = 50000, ShipId = 3, ToDate = new DateTime(2021,10,18)},
            new ReservationDTO { Id = 2, FromDate = new DateTime(2021,9,16), PersonId = 1, Price = 70000, ShipId = 2, ToDate = new DateTime(2021,9,18)},
        };

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            return Ok(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(ReservationDTO reserv)
        {
            reservations.Add(reserv);
            return Ok(reservations);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = reservations.FirstOrDefault(h => h.Id == id);
            if (reservation == null)
                return NotFound("Reservation was not found");

            reservations.Remove(reservation);
            return Ok(reservations);
        }
    }
}
