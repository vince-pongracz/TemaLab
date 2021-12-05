using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Services.ShipImageService;

namespace WebProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IShipImageService _shipImageService;

        public ImagesController(IShipImageService shipImageService)
        {
            _shipImageService = shipImageService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetImagesById(int id)
        {
            return Ok(await _shipImageService.GetImagesById(id));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllImage()
        {
            return Ok(await _shipImageService.GetAllImages());
        }
    }
}
