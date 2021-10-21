using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services
{
    public interface IReservationService
    {
        Task<List<ReservationDTO>> GetReservations();

        Task<List<ReservationDTO>> CreateReservation(ReservationDTO reserv);

        Task<List<ReservationDTO>> DeleteReservation(int id);
    }
}
