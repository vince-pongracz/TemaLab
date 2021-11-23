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
        //indicates when the task was successful (posted ranking is regular and valid)
        Task<bool> CreateRanking(RankingDTO rankingDTO);
    }
}