using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Ship> GetShip(int id)
        {
            return await _httpClient.GetFromJsonAsync<Ship>($"api/ships/{id}");
        }

        public async Task<List<Ship>> GetShips()
        {
            return await _httpClient.GetFromJsonAsync<List<Ship>>("api/ships");
        }
    }
}
