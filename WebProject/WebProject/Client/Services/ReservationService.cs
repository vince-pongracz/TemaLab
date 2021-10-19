using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HttpClient _httpClient;

        public ReservationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Reservation>> CreateReservation(Reservation reserv)
        {
            var result = await _httpClient.PostAsJsonAsync("api/reservations", reserv);
            var reservations = await result.Content.ReadFromJsonAsync<List<Reservation>>();
            return reservations;
        }

        public async Task<List<Reservation>> GetReservations()
        {
            return await _httpClient.GetFromJsonAsync<List<Reservation>>("api/reservations");
        }
    }
}
