using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Data;
using WebProject.Server.Models;
using WebProject.Shared;

namespace WebProject.Server.Services.RankingService
{
    public class RankingService : IRankingService
    {
        private readonly ApplicationDbContext _context;

        [Inject]
        public IMapper Mapper { get; set; }

        public RankingService(ApplicationDbContext context)
        {
            _context = context;
            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MapperConfigService())));
        }

        public async Task<List<RankingDTO>> GetRankings()
        {
            var rankings = await _context.Rankings.ToListAsync();
            return Mapper.Map(rankings, new List<RankingDTO>());
        }

        public async Task<List<RankingDTO>> GetRankingsForShip(int shipid)
        {
            var rankings = await _context.Rankings.Where(x => x.ShipId == shipid).ToListAsync();
            return Mapper.Map(rankings, new List<RankingDTO>());
        }

        public async Task CreateRanking(RankingDTO rankingDTO)
        {
            _context.Rankings.Add(Mapper.Map(rankingDTO, new Ranking()));
            await _context.SaveChangesAsync();
        }
    }
}
