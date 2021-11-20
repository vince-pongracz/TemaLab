using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services
{
    public interface IReservationService
    {
        event Action OnChange;

        Task<List<ReservationGetDTO>> GetReservations();

        Task<List<ReservationGetDTO>> CreateReservation(ReservationPostDTO reservation);

        Task<List<ReservationGetDTO>> DeleteReservation(int id);
    }
}
