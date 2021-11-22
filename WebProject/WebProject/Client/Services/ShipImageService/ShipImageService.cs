using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services.ShipImageService
{
    public class ShipImageService : IShipImageService
    {
        private readonly HttpClient _httpClient;

        public ShipImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ShipImageDTO>> GetImagesById(int id)
        {
            var images = await _httpClient.GetFromJsonAsync<List<ShipImageDTO>>($"api/images/{id}");
            return images;
        }
    }
}
