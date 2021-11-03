using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
    public class ShipsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly NavigationManager NavigationManager;

        [Inject]
        public IMapper Mapper { get; set; }

        public ShipsController(ApplicationDbContext context, NavigationManager navigation)
        {
            _context = context;
            NavigationManager = navigation;
            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MapperConfigService())));
        }

        [HttpGet]
        public async Task<IActionResult> GetShips()
        {
            return Ok(Mapper.Map(await _context.Ships.ToListAsync(), new List<ShipDTO>()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingleShip(int id)
        {
            Ship ship = await _context.Ships.FirstOrDefaultAsync(s => s.Id == id);
            if (ship == null)
                return NotFound("Ship was not found");
            return Ok(Mapper.Map(ship, new ShipDTO()));
        }

        [HttpGet]
        [Route("api/search")]
        public async Task<IActionResult> SearchShips(string query)
        {
            DateTime? from;
            DateTime? until;
            int? persons;
            string port;

            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);

            var queryResult = _context.Ships.Where(x => x.IsAvailable && !x.IsDeleted);

            if (QueryHelpers.ParseQuery(query).TryGetValue("from", out var paramFrom))
            {
                from = DateTime.Parse(paramFrom.First());
                //TODO from filter
                //if(from != default) ...
            }
            if (QueryHelpers.ParseQuery(query).TryGetValue("until", out var paramUntil))
            {
                until = DateTime.Parse(paramUntil.First());
                //if(from != default) ...
                //TODO until filter
            }
            if (QueryHelpers.ParseQuery(query).TryGetValue("persons", out var paramPersons))
            {
                persons = int.Parse(paramPersons.First());
                if (persons != default) queryResult = queryResult.Where(x => x.PersonsMax <= persons.Value);
            }
            if (QueryHelpers.ParseQuery(query).TryGetValue("port", out var paramPort))
            {
                port = paramPort.First();
                if (!string.IsNullOrEmpty(port)) queryResult = queryResult.Where(x => x.HomePort.Contains(port));
            }

            return Ok(Mapper.Map(await queryResult.ToListAsync(), new List<ShipDTO>()));
        }
    }
}
