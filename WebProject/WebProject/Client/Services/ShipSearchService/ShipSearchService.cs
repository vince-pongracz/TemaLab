using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Json;
using System.Text;
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

        public async Task<List<ShipDTO>> SearchShips(DateTime? from = default, DateTime? until = default, int? maxPersons = default, string where = default)
        {
            var queryBuilder = new QueryBuilder();

            if (from.HasValue && from.Value != default) queryBuilder.Add("from", from.ToString());
            if (until.HasValue && until.Value != default) queryBuilder.Add("until", until.ToString());
            if (maxPersons.HasValue) queryBuilder.Add("maxPersons", maxPersons.ToString());
            if (!string.IsNullOrWhiteSpace(where)) queryBuilder.Add("where", where.ToString());

            var queryString = queryBuilder.ToQueryString();

            var response = await _httpClient.GetAsync($"api/search{queryString}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ShipDTO>>();
            }
            else
            {
                throw new InvalidOperationException("Wrong search criterias");
            }
        }
    }
}
