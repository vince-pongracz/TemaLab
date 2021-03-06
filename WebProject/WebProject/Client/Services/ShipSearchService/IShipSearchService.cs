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

        Task<List<ShipDTO>> GetAvailableShips();

        Task<ShipDTO> GetShip(int id);

        Task<List<ShipDTO>> SearchShips(DateTime? from, DateTime? until, int? maxPersons,string where);

        Task<List<ShipDTO>> GetOwnedShipsForUser();

        Task<ShipDTO> UpdateShipAvailability(ShipDTO hipDTO, int id);
    }
}
