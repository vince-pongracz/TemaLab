using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string userName) : base(userName)
        {
            this.UserName = userName;
        }

        public string FacebookLink { get; set; }

        public string InstagramLink { get; set; }

        public List<Ranking> Rankings { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<Ship> OwnedShips { get; set; }
    }
}
