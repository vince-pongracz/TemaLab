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
using WebProject.Server.Services.ReservationService;
using WebProject.Shared;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            return Ok(await _reservationService.GetReservations());
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(ReservationGetDTO reservationDTO)
        {
            //TODO validate, set isAvailable to true, etc..
            await _reservationService.CreateReservation(reservationDTO);
            return await GetReservations();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            if (await _reservationService.DeleteReservation(id) == null)
                return NotFound("Reservation was not found");
            else
                return await GetReservations();
        }
    }
}
