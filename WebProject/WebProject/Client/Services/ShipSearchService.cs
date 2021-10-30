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

        public async Task<ShipDTO> GetShip(int id)
        {
            return await _httpClient.GetFromJsonAsync<ShipDTO>($"api/ships/{id}");
        }

        public async Task<List<ShipDTO>> GetShips()
        {
            return await _httpClient.GetFromJsonAsync<List<ShipDTO>>($"api/ships");
        }

        public async Task<List<ShipDTO>> GetShips(Expression queryExp)
        {
            return await _httpClient.GetFromJsonAsync<List<ShipDTO>>($"api/ships/{queryExp}");
            //TODO how to pass a query?
        }
    }
}
