using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Models;
using WebProject.Shared;

namespace WebProject.Server.Services
{
    public class MapperConfigService : Profile
    {
        // DOC : https://docs.automapper.org/en/stable/Configuration.html
        public MapperConfigService()
        {
            //map between ships
            CreateMap<Ship, ShipDTO>();
            CreateMap<ShipDTO, Ship>();

            //map between rankings
            CreateMap<Ranking, RankingDTO>();
            CreateMap<RankingDTO, Ranking>();

            //map between reservations
            CreateMap<Reservation, ReservationGetDTO>();
            CreateMap<ReservationGetDTO, Reservation>();
            //---
            CreateMap<Reservation, ReservationPostDTO>();
            CreateMap<ReservationPostDTO, Reservation>();

            //map between users
            CreateMap<ApplicationUser, ApplicationUserDTO>();
            CreateMap<ApplicationUserDTO, ApplicationUser>();
        }
    }
}
