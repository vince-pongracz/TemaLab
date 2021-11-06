using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services.RankingService
{
    public class RankingService : IRankingService
    {

        private readonly HttpClient _httpClient;

        public RankingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<RankingDTO> rankings { get; set; } = new List<RankingDTO>();

        public event Action OnChange;

        public async Task<List<RankingDTO>> CreateRanking(RankingDTO ranking)
        {
            var result = await _httpClient.PostAsJsonAsync("api/rankings", ranking);
            rankings = await result.Content.ReadFromJsonAsync<List<RankingDTO>>();
            OnChange.Invoke();
            return rankings;
        }

        public async Task<List<RankingDTO>> GetRankings()
        {
            rankings = await _httpClient.GetFromJsonAsync<List<RankingDTO>>("api/rankings");
            return rankings;
        }

        public async Task<List<RankingDTO>> GetRankingsForShip(int shipid)
        {
            rankings = await _httpClient.GetFromJsonAsync<List<RankingDTO>>($"api/rankings/{shipid}");
            return rankings;
        }

    }
}
