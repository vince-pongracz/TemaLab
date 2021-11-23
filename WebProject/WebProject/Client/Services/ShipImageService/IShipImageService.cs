using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services.ShipImageService
{
    interface IShipImageService
    {
        Task<List<ShipImageDTO>> GetImagesById(int shipid);
    }
}
