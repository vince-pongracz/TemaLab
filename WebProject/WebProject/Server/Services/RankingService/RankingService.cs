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

        public async Task<bool> CreateRanking(RankingDTO rankingDTO)
        {
            //2 weeks as ranking writing permission
            var twoWeeks = 14;
            var reservations = _context.Reservations.ToList();
            var canWriteRanking = (from res in _context.Reservations
                                   where res.ShipId == rankingDTO.ShipId &&
                                         res.ApplicationUserId == rankingDTO.UserId &&
                                         res.ToDate.AddDays(twoWeeks) >= rankingDTO.Date &&
                                         res.FromDate < rankingDTO.Date
                                   orderby res.ToDate descending
                                   select res).Any();

            if (canWriteRanking)
            {
                var newRanking = Mapper.Map(rankingDTO, new Ranking());

                newRanking.Ship = _context.Ships.Where(x => x.Id == newRanking.ShipId).FirstOrDefault();
                newRanking.User = _context.Users.Where(x => x.Id == newRanking.UserId).FirstOrDefault();

                _context.Rankings.Add(newRanking);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
