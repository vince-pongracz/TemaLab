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
    public class RankingsController : ControllerBase
    {
        List<Ranking> rankings = new List<Ranking>
        {
            new Ranking { Id = 1, Comment = "wdfsdfsf", Date = new DateTime(2021,8,5), PersonID = 5, ShipId = 4, Stars = 3},
            new Ranking { Id = 2, Comment = "iopoip", Date = new DateTime(2025,5,5), PersonID = 4, ShipId = 6, Stars = 5}
        };

        public async Task<IActionResult> GetReservations()
        {
            return Ok(rankings);
        }
    }
}
