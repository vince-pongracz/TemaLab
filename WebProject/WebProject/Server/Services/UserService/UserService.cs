using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebProject.Server.Data;
using WebProject.Shared;
using WebProject.Server.Models;

namespace WebProject.Server.Services.UserService
{
    public class UserService : Controller, IUserService
    {
        private readonly ApplicationDbContext _context;

        [Inject]
        public IMapper Mapper { get; set; }

        public UserService(ApplicationDbContext context)
        {
            _context = context;
            Mapper = new Mapper(new MapperConfiguration(c => c.AddProfile(new MapperConfigService())));
        }

        public async Task<ApplicationUserDTO> GetCurrentUser(string userId)
        {
            var user = Mapper.Map(await _context.Users.FirstOrDefaultAsync(u => u.Id == userId), new ApplicationUserDTO());
            return user;
        }

        public Task<string> GetCurrentLoggedInUserID()
        {
            // DOC : https://stackoverflow.com/questions/30701006/how-to-get-the-current-logged-in-user-id-in-asp-net-core
            // will give the user's userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Task.FromResult(userId);
        }
    }
}
