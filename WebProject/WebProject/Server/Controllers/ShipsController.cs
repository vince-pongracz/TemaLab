using AutoMapper;
using Microsoft.AspNetCore.Components;
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
    }
}
