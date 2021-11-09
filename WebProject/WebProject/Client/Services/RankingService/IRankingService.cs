using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services.RankingService
{
    public interface IRankingService
    {
        event Action OnChange;

        List<RankingDTO> rankings { get; set; }

        Task<List<RankingDTO>> GetRankings();

        Task<List<RankingDTO>> GetRankingsForShip(int shipid);

        Task<List<RankingDTO>> CreateRanking(RankingDTO ranking);
    }
}
