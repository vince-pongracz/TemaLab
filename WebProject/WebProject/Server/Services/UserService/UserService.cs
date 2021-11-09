using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebProject.Server.Models;

namespace WebProject.Server.Services.UserService
{
    public class UserService : Controller, IUserService
    {
        public Task<string> GetCurrentLoggedInUser()
        {
            // DOC : https://stackoverflow.com/questions/30701006/how-to-get-the-current-logged-in-user-id-in-asp-net-core
            // will give the user's userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            return Task.FromResult(userId);
        }
    }
}
