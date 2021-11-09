using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services
{
    public interface IShipSearchService
    {
        List<ShipDTO> Ships { get; set; }
        Task<List<ShipDTO>> GetShips();

        Task<ShipDTO> GetShip(int id);

        Task<List<ShipDTO>> SearchShips(DateTime? from, DateTime? until, int? maxPersons,string where);
    }
}
