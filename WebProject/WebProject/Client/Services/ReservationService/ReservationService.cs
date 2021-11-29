using Microsoft.AspNetCore.Http.Extensions;
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

        public List<ReservationGetDTO> Reservations { get; set; } = new List<ReservationGetDTO>();

        public event Action OnChange;
        public async Task<List<ReservationGetDTO>> GetReservations()
        {
            Reservations = await _httpClient.GetFromJsonAsync<List<ReservationGetDTO>>("api/reservations");
            return Reservations;
        }
        public async Task<List<ReservationGetDTO>> CreateReservation(ReservationPostDTO reservation)
        {
            var result = await _httpClient.PostAsJsonAsync("api/reservations", reservation);
            Reservations = await result.Content.ReadFromJsonAsync<List<ReservationGetDTO>>();
            return Reservations;
        }

        public async Task<List<ReservationGetDTO>> DeleteReservation(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/reservations/{id}");
            Reservations = await result.Content.ReadFromJsonAsync<List<ReservationGetDTO>>();
            OnChange.Invoke();
            return Reservations;
        }

        public async Task<List<ReservationGetDTO>> GetIncomingBookings()
        {
            Reservations = await _httpClient.GetFromJsonAsync<List<ReservationGetDTO>>("api/reservations/incomingBookings");
            return Reservations;
        }

        public async Task<List<ReservationGetDTO>> ApproveReservation(int reservationId)
        {
            var postBody = new ReservationPostDTO() { Id = reservationId };
            var result = await _httpClient.PostAsJsonAsync("api/reservations/incomingBookings", postBody);
            Reservations = await result.Content.ReadFromJsonAsync<List<ReservationGetDTO>>();
            return Reservations;
        }
    }
}
