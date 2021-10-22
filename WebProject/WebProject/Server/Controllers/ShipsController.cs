using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Data;
using WebProject.Server.Models;

namespace WebProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetShips()
        {
            return Ok(await _context.Ships.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleShip(int id)
        {
            Ship ship = await _context.Ships.FirstOrDefaultAsync(s => s.Id == id);
            if (ship == null)
                return NotFound("Ship was not found");
            return Ok(ship);
        }
    }
}
