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

        public List<ReservationGetDTO> reservations { get; set; } = new List<ReservationGetDTO>();

        public event Action OnChange;

        public async Task<List<ReservationGetDTO>> CreateReservation(ReservationPostDTO reserv)
        {
            var result = await _httpClient.PostAsJsonAsync("api/reservations", reserv);
            reservations = await result.Content.ReadFromJsonAsync<List<ReservationGetDTO>>();
            return reservations;
        }

        public async Task<List<ReservationGetDTO>> DeleteReservation(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/reservations/{id}");
            reservations = await result.Content.ReadFromJsonAsync<List<ReservationGetDTO>>();
            OnChange.Invoke();
            return reservations;
        }

        public async Task<List<ReservationGetDTO>> GetReservations()
        {
            reservations = await _httpClient.GetFromJsonAsync<List<ReservationGetDTO>>("api/reservations");
            return reservations;
        }
    }
}
