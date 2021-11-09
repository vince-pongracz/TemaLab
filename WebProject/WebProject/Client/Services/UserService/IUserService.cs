﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services.UserService
{
    interface IUserService
    {
        Task<ApplicationUserDTO> GetCurrentUser();
    }
}
