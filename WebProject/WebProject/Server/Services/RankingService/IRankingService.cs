using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Server.Services.RankingService
{
    public interface IRankingService
    {
        Task<List<RankingDTO>> GetRankings();
        Task<List<RankingDTO>> GetRankingsForShip(int shipId);
        Task CreateRanking(RankingDTO rankingDTO);
    }
}