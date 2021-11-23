using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Client.Services.UserService;
using WebProject.Server.Data;
using WebProject.Server.Models;
using WebProject.Server.Services;
using WebProject.Server.Services.RankingService;
using WebProject.Shared;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingsController : ControllerBase
    {
        private readonly IRankingService _rankingService;
        
        public RankingsController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRankings()
        {
            return Ok(await _rankingService.GetRankings());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRankingsForShip(int id)
        {
            return Ok(await _rankingService.GetRankingsForShip(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRanking(RankingDTO rankingDTO)
        {
            var result = await _rankingService.CreateRanking(rankingDTO);
            if (result) return Ok(await GetRankings());
            else return Forbid();
        }
    }
}
