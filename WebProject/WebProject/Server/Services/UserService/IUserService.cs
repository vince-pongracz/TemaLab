using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Server.Services.UserService
{
    public interface IUserService
    {
        Task<ApplicationUserDTO> GetCurrentUser(string userId);
        Task<string> GetCurrentLoggedInUserID();
    }
}
