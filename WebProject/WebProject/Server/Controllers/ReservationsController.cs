﻿using Microsoft.AspNetCore.Http;
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
        static List<Reservation> reservations = new List<Reservation>
        {
            new Reservation { Id = 1, FromDate = new DateTime(2021,10,16), PersonId = 2, Price = 50000, ShipId = 3, ToDate = new DateTime(2021,10,18)},
            new Reservation { Id = 2, FromDate = new DateTime(2021,9,16), PersonId = 1, Price = 70000, ShipId = 2, ToDate = new DateTime(2021,9,18)},
        };

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            return Ok(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reserv)
        {
            reservations.Add(reserv);
            return Ok(reservations);
        }
    }
}
