using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Server.Services.UserService
{
    public interface IUserService
    {
        Task<string> GetCurrentLoggedInUser();
    }
}
