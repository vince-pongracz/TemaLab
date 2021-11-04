using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Url]
        public string FacebookLink { get; set; }

        [Url]
        public string InstagramLink { get; set; }
        
        public List<Ranking> Rankings { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<Ship> OwnedShips { get; set; }

        public ApplicationUser()
        {

        }
    }
}
