using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Server.Services.ShipImageService
{
    public interface IShipImageService
    {
        Task<List<ShipImageDTO>> GetImagesById(int shipId);
        Task<List<ShipImageDTO>> GetAllImages();
    }
}
