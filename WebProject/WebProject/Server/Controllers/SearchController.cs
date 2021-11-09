using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Data;
using WebProject.Server.Services;
using WebProject.Shared;

namespace WebProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IMapper Mapper { get; set; }

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MapperConfigService())));
        }

        [HttpGet]
        public async Task<IActionResult> SearchShips([FromQuery] SearchCriteriaDTO searchCriteria)
        {
            var queryResultShips = _context.Ships.Where(x => x.IsAvailable && !x.IsDeleted);

            if (searchCriteria.From != default)
            {
                //query such reservations, where the startdate of the current reservation is not in an other reservation timeslot
                var shipsWithOkStartDate = from res in _context.Reservations
                                           where !(
                                                res.FromDate <= searchCriteria.From &&
                                                searchCriteria.From < res.ToDate)
                                           select res.ShipId;
                if (shipsWithOkStartDate.Any())
                    queryResultShips = queryResultShips.Where(x => shipsWithOkStartDate.Contains(x.Id));
            }
            if (searchCriteria.Until != default)
            {
                //query such reservations, where the enddate of the current reservation is not in an other reservation timeslot
                var shipsWithOkEndDate = from res in _context.Reservations
                                         where !(
                                            res.FromDate <= searchCriteria.Until &&
                                            searchCriteria.Until < res.ToDate)
                                         select res.ShipId;
                if (shipsWithOkEndDate.Any())
                    queryResultShips = queryResultShips.Where(x => shipsWithOkEndDate.Contains(x.Id));
            }
            if (searchCriteria.From != default && searchCriteria.Until != default)
            {
                //query such reservations, where the start and end date of the current reservation is longer than the actual reservation
                var filterTooLongReservations = from res in _context.Reservations
                                                where !(
                                                    searchCriteria.From <= res.FromDate &&
                                                    res.ToDate < searchCriteria.Until)
                                                select res.ShipId;
                if (filterTooLongReservations.Any())
                    queryResultShips = queryResultShips.Where(x => filterTooLongReservations.Contains(x.Id));
            }
            if (searchCriteria.MaxPersons != null)
            {
                queryResultShips = queryResultShips.Where(x => x.MaxPeople >= searchCriteria.MaxPersons.Value);
            }
            if (!string.IsNullOrEmpty(searchCriteria.Port)) queryResultShips = queryResultShips.Where(x => x.HomePort.Contains(searchCriteria.Port));

            return Ok(Mapper.Map(await queryResultShips.ToListAsync(), new List<ShipDTO>()));
        }
    }
}
