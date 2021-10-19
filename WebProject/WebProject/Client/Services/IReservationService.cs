using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetReservations();

        Task<List<Reservation>> CreateReservation(Reservation reserv);
    }
}
