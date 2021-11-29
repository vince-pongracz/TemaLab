using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public partial class ShipsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        [Inject]
        public IMapper Mapper { get; set; }

        public ShipsController(ApplicationDbContext context, NavigationManager navigation)
        {
            _context = context;
            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MapperConfigService())));
        }

        [HttpGet]
        public async Task<IActionResult> GetShips()
        {
            return Ok(Mapper.Map(await _context.Ships.Where(x => x.IsAvailable && !x.IsDeleted).ToListAsync(), new List<ShipDTO>()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingleShip(int id)
        {
            Ship ship = await _context.Ships.FirstOrDefaultAsync(s => s.Id == id);
            if (ship == null)
                return NotFound("Ship was not found");
            return Ok(Mapper.Map(ship, new ShipDTO()));
        }

        [HttpGet("OwnedShips")]
        public async Task<IActionResult> GetOwnedShipsForUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(Mapper.Map(await _context.Ships.Where(x => x.OwnerId == userId).ToListAsync(), new List<ShipDTO>()));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateShipAvailability(int id, ShipDTO shipDTO)
        {
            try
            {
                var shipToUpdate = await _context.Ships.FirstOrDefaultAsync(s => s.Id == id);

                if (shipToUpdate == null)
                    return NotFound($"Ship with Id = {id} not found");

                shipToUpdate.IsAvailable = shipDTO.IsAvailable;
                await _context.SaveChangesAsync();

                return Ok(Mapper.Map(shipToUpdate, new ShipDTO()));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
    }
}
