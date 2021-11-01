using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services.RankingService
{
    public interface IRankingService
    {
        List<RankingDTO> rankings { get; set; }

        Task<List<RankingDTO>> GetRankings();

        Task<List<RankingDTO>> CreateRanking(RankingDTO ranking);
    }
}
