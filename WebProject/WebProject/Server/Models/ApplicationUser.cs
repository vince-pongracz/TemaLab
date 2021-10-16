using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public ApplicationUser(string userName) : base(userName)
        {
            this.UserName = userName;
        }
    }
}
