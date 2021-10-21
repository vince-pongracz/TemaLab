﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services
{
    public interface IShipSearchService
    {
        Task<List<ShipDTO>> GetShips();

        Task<ShipDTO> GetShip(int id);
    }
}
