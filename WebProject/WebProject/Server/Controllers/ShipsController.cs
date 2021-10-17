using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Models;

namespace WebProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipsController : ControllerBase
    {
        //mock data
        List<Ship> ships = new List<Ship>
        {
            new Ship { Id = 1, Caution = 50000, Description = "it's a ship", Drought = 5, HomePort = "Balatonfured", IsAvailable  = true, IsDeleted = false, Lenght = 12, Manufacturer = "ship.kft", Name = "Carol", PersonId = 1, PersonsMax = 5, PriceAtWeekDays = 10000, PriceAtWeekEnds = 12000, ProductionYear = 2005, ShipType = "fancy", Weight = 2600, Width = 5},
            new Ship { Id = 2, Caution = 80000, Description = "it's a ship", Drought = 6, HomePort = "Sopron", IsAvailable  = true, IsDeleted = false, Lenght = 15, Manufacturer = "ship2.kft", Name = "Awesome", PersonId = 2, PersonsMax = 7, PriceAtWeekDays = 20000, PriceAtWeekEnds = 22000, ProductionYear = 2010, ShipType = "very fancy", Weight = 3600, Width = 7},
        };

        public async Task<IActionResult> GetShips()
        {
            return Ok(ships);
        }
    }
}
