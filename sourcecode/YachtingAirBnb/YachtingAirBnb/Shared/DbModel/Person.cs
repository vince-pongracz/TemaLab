using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YachtingAirBnb.Shared.DbModel
{
    public class Person : IdentityUser
    {
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public Person(string userName) : base(userName)
        {
            this.UserName = userName;
        }
    }
}
