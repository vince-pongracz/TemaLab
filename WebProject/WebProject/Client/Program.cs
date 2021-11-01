using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebProject.Client.Services;
using WebProject.Client.Services.RankingService;

namespace WebProject.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

           builder.Services.AddHttpClient("WebProject.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
           
            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WebProject.ServerAPI"));

            builder.Services.AddApiAuthorization();

            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IShipSearchService, ShipSearchService>();
            builder.Services.AddScoped<IRankingService, RankingService>();

            await builder.Build().RunAsync();
        }
    }
}
