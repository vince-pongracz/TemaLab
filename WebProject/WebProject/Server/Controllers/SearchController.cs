using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebProject.Server.Data;
using WebProject.Server.Models;
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
            try
            {
                //check data from query
                if (searchCriteria.MaxPersons <= 0)
                    throw new ArgumentOutOfRangeException($"Max amount of people can not be negative number ({searchCriteria.MaxPersons})!");

                var queryResultShips = _context.Ships.Where(x => x.IsAvailable && !x.IsDeleted);

                if (searchCriteria.From != default)
                {
                    if (searchCriteria.From < DateTime.Now)
                        throw new ArgumentOutOfRangeException($"Start date should be referred later!");

                    //query such reservations, where the startdate of the current reservation is not in an other reservation timeslot
                    var shipsWithNotOkStartDate = from res in _context.Reservations
                                                  where
                                                    (res.FromDate <= searchCriteria.From &&
                                                    searchCriteria.From < res.ToDate)
                                                  select res.ShipId;
                    //if (shipsWithNotOkStartDate.Any())
                    queryResultShips = queryResultShips.Where(x => !shipsWithNotOkStartDate.Contains(x.Id));
                }
                if (searchCriteria.Until != default)
                {
                    if (DateTime.Now > searchCriteria.Until)
                        throw new ArgumentOutOfRangeException($"End date should be referred later!");
                    //query such reservations, where the enddate of the current reservation is not in an other reservation timeslot
                    var shipsWithNotOkEndDate = from res in _context.Reservations
                                                where
                                                    (res.FromDate <= searchCriteria.Until &&
                                                    searchCriteria.Until < res.ToDate)
                                                select res.ShipId;
                    //if (shipsWithNotOkEndDate.Any())
                    queryResultShips = queryResultShips.Where(x => !shipsWithNotOkEndDate.Contains(x.Id));
                }
                if (searchCriteria.From != default && searchCriteria.Until != default)
                {
                    //check if the bounds are correct (if the dates are changed)
                    if (searchCriteria.From > searchCriteria.Until)
                        throw new ArgumentOutOfRangeException($"Start date of the reservation should be earlier than the end date!");

                    //query such reservations, where the start and end date of the current search criteria is longer than an existing reservation
                    var filterTooLongReservations = from res in _context.Reservations
                                                    where (searchCriteria.From <= res.FromDate &&
                                                          res.ToDate < searchCriteria.Until)
                                                    select res.ShipId;
                    //if (filterTooLongReservations.Any())
                    queryResultShips = queryResultShips.Where(x => !filterTooLongReservations.Contains(x.Id));
                }



                if (searchCriteria.MaxPersons != null)
                {
                    queryResultShips = queryResultShips.Where(x => x.MaxPeople >= searchCriteria.MaxPersons.Value);
                }
                if (!string.IsNullOrEmpty(searchCriteria.Port)) queryResultShips = queryResultShips.Where(x => x.HomePort.Contains(searchCriteria.Port));

                return Ok(Mapper.Map(await queryResultShips.ToListAsync(), new List<ShipDTO>()));

            }
            catch (ArgumentOutOfRangeException e)
            {
                //for bad request return an empty list indicating that's wrong...
                return BadRequest(Mapper.Map(new List<Ship>(), new List<ShipDTO>()));
            }
        }
    }
}
