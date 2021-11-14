using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApplicationUserDTO> GetCurrentUser()
        {
            return await _httpClient.GetFromJsonAsync<ApplicationUserDTO>("api/users");
        }

        public async Task<ApplicationUserDTO> GetUserByID(string Id)
        {
            return await _httpClient.GetFromJsonAsync<ApplicationUserDTO>($"api/users/{Id}");
        }
    }
}
