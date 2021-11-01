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

        public async Task<List<RankingDTO>> CreateRanking(RankingDTO ranking)
        {
            var result = await _httpClient.PostAsJsonAsync("api/rankings", ranking);
            var rankings = await result.Content.ReadFromJsonAsync<List<RankingDTO>>();
            return rankings;
        }

        public async  Task<List<RankingDTO>> GetRankings()
        {
            return await _httpClient.GetFromJsonAsync<List<RankingDTO>>($"api/rankings");
        }
    }
}
