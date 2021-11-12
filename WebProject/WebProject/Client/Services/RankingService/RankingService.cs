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

        private List<RankingDTO> Rankings { get; set; } = new List<RankingDTO>();

        public event Action OnChange;

        public async Task<List<RankingDTO>> CreateRanking(RankingDTO ranking)
        {
            var result = await _httpClient.PostAsJsonAsync("api/rankings", ranking);
            if (result.IsSuccessStatusCode)
            {
                return await GetRankings();
            }
            else
            {
                return new List<RankingDTO>();
            }
        }

        public async Task<List<RankingDTO>> GetRankings()
        {
            Rankings = await _httpClient.GetFromJsonAsync<List<RankingDTO>>("api/rankings");
            return Rankings;
        }

        public async Task<List<RankingDTO>> GetRankingsForShip(int id)
        {
            Rankings = await _httpClient.GetFromJsonAsync<List<RankingDTO>>($"api/rankings/{id}");
            return Rankings;
        }

    }
}
