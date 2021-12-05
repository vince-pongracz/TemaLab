using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Data;
using WebProject.Shared;

namespace WebProject.Server.Services.ShipImageService
{
    public class ShipImageService : IShipImageService
    {
        private readonly ApplicationDbContext _context;

        [Inject]
        public IMapper Mapper { get; set; }

        public ShipImageService(ApplicationDbContext context)
        {
            _context = context;
            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MapperConfigService())));
        }

        public async Task<List<ShipImageDTO>> GetImagesById(int shipId)
        {
            var images = await _context.Images.Where(x => x.ShipId == shipId).ToListAsync();
            return Mapper.Map(images, new List<ShipImageDTO>());
        }

        public async Task<List<ShipImageDTO>> GetAllImages()
        {
            return Mapper.Map(await _context.Images.ToListAsync(), new List<ShipImageDTO>());
        }
    }
}
