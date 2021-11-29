using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Models;
using WebProject.Shared;

namespace WebProject.Server.Services.ReservationService
{
    public interface IReservationService
    {
        Task<List<ReservationGetDTO>> GetReservations(string userID);
        Task<List<ReservationGetDTO>> GetIncomingBookings(string actualLoggedInUserId);
        Task CreateReservation(ReservationGetDTO reservationDTO);
        Task<Reservation> DeleteReservation(int id);
    }
}
