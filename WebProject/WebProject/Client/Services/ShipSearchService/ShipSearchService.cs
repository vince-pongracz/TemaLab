using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services
{
    public class ShipSearchService : IShipSearchService
    {
        private readonly HttpClient _httpClient;

        public ShipSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<ShipDTO> Ships { get; set; }

        public async Task<ShipDTO> GetShip(int id)
        {
            return await _httpClient.GetFromJsonAsync<ShipDTO>($"api/ships/{id}");
        }

        public async Task<List<ShipDTO>> GetShips()
        {
            Ships = await _httpClient.GetFromJsonAsync<List<ShipDTO>>($"api/ships");
            return Ships;
        }

        public async Task<List<ShipDTO>> SearchShips(string query)
        {
            return await _httpClient.GetFromJsonAsync<List<ShipDTO>>($"api/search/{query}");
        }
    }
}
