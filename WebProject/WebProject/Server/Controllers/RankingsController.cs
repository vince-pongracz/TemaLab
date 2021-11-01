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
using WebProject.Shared;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        [Inject]
        public IMapper Mapper { get; set; }

        public RankingsController(ApplicationDbContext context)
        {
            _context = context;
            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MapperConfigService())));
        }

        [HttpGet]
        public async Task<IActionResult> GetRankings()
        {
            return Ok(Mapper.Map(await _context.Rankings.ToListAsync(), new List<RankingDTO>()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRanking(RankingDTO rankingDTO)
        {
            _context.Rankings.Add(Mapper.Map(rankingDTO, new Ranking()));
            await _context.SaveChangesAsync();

            return await GetRankings();
        }
    }
}
