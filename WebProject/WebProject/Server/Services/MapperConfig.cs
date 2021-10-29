using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Models;
using WebProject.Shared;

namespace WebProject.Server.Services
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //map between ships
            CreateMap<Ship, ShipDTO>();
            CreateMap<ShipDTO, Ship>();

            CreateMap<Ranking, RankingDTO>();
            CreateMap<RankingDTO, Ranking>();

            CreateMap<Reservation, ReservationGetDTO>();
            CreateMap<ReservationGetDTO, Reservation>();

            CreateMap<ApplicationUser, ApplicationUserDTO>();
            CreateMap<ApplicationUserDTO, ApplicationUser>();
        }
    }
}
