using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Models;

namespace WebProject.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { Id = 1, ApplicationUserId = "0e40245d-d108-4236-a833-3628e645d097", FromDate = new DateTime(2021, 10, 22), Price = 55555, ShipId = 1, ToDate = new DateTime(2021, 10, 25) },
                new Reservation { Id = 2, ApplicationUserId = "0e40245d-d108-4236-a833-3628e645d097", FromDate = new DateTime(2021, 10, 23), Price = 66666, ShipId = 2, ToDate = new DateTime(2021, 10, 25) },
                new Reservation { Id = 3, ApplicationUserId = "0e40245d-d108-4236-a833-3628e645d097", FromDate = new DateTime(2021, 10, 24), Price = 77777, ShipId = 3, ToDate = new DateTime(2021, 10, 25) },
                new Reservation { Id = 4, ApplicationUserId = "0e40245d-d108-4236-a833-3628e645d097", FromDate = new DateTime(2021, 10, 26), Price = 88888, ShipId = 4, ToDate = new DateTime(2021, 10, 25) }
            );

            modelBuilder.Entity<Ship>().HasData(
                new Ship { Id = 1, Caution = 555555, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus rutrum arcu sit amet enim euismod, sed mattis quam pellentesque....", Draught = 15, HomePort = "Sopron", IsAvailable = true, IsDeleted = false, Length = 10, Manufacturer = "ship.kft", MaxPeople = 10, Name = "Carol", OwnerId = "0e40245d-d108-4236-a833-3628e645d097", PriceAtWeekDays = 10000, PriceAtWeekEnds = 12000, ProductionYear = 1999, ShipType = "fancy", Weight = 1500, Width = 5 },
                new Ship { Id = 2, Caution = 555555, Description = "Mauris dui nisl, suscipit id fringilla id, efficitur sed erat...", Draught = 15, HomePort = "Balatonfüred", IsAvailable = true, IsDeleted = false, Length = 10, Manufacturer = "ship.kft", MaxPeople = 5, Name = "Awesome", OwnerId = "0e40245d-d108-4236-a833-3628e645d097", PriceAtWeekDays = 20000, PriceAtWeekEnds = 22000, ProductionYear = 1999, ShipType = "fancy", Weight = 1500, Width = 5 },
                new Ship { Id = 3, Caution = 555555, Description = "Ut sit amet tellus eu elit egestas tempor. Sed ut tortor malesuada, posuere leo non, hendrerit turpis. ...", Draught = 15, HomePort = "Tisza-tó", IsAvailable = true, IsDeleted = false, Length = 10, Manufacturer = "ship.kft", MaxPeople = 12, Name = "Jazz", OwnerId = "0e40245d-d108-4236-a833-3628e645d097", PriceAtWeekDays = 30000, PriceAtWeekEnds = 32000, ProductionYear = 1999, ShipType = "fancy", Weight = 1500, Width = 5 },
                new Ship { Id = 4, Caution = 555555, Description = "Etiam eu eros id turpis volutpat mollis sed vitae metus. Ut suscipit lectus enim...", Draught = 15, HomePort = "Velencei-tó", IsAvailable = true, IsDeleted = false, Length = 10, Manufacturer = "ship.kft", MaxPeople = 14, Name = "Sina", OwnerId = "0e40245d-d108-4236-a833-3628e645d097", PriceAtWeekDays = 40000, PriceAtWeekEnds = 42000, ProductionYear = 1999, ShipType = "fancy", Weight = 1500, Width = 5 }
            );

            modelBuilder.Entity<Ranking>().HasData(
                new Ranking { Date = new DateTime(2021,11,05), Id = 1, ShipId = 1, Stars = 4, UserId = "0e40245d-d108-4236-a833-3628e645d097", Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus rutrum arcu sit amet enim euismod, sed mattis quam pellentesque. Proin porttitor ullamcorper euismod. " },
                new Ranking { Date = new DateTime(2021,11,06), Id = 2, ShipId = 1, Stars = 5, UserId = "0e40245d-d108-4236-a833-3628e645d097", Comment = "Nulla ut odio sem. Donec convallis, arcu ac convallis posuere, ipsum ligula dapibus neque, ullamcorper vulputate nunc ipsum in enim. Aliquam finibus quam vitae justo tincidunt, eu viverra diam suscipit. Donec sodales at enim sollicitudin dignissim. Praesent aliquam venenatis nulla, et pulvinar massa ullamcorper et. " },
                new Ranking { Date = new DateTime(2021, 11, 03), Id = 3, ShipId = 2, Stars = 1, UserId = "0e40245d-d108-4236-a833-3628e645d097", Comment = "Ut sit amet tellus eu elit egestas tempor. Sed ut tortor malesuada, posuere leo non, hendrerit turpis. Nam imperdiet tincidunt ultricies. Nulla sit amet est a velit ornare aliquet. " },
                new Ranking { Date = new DateTime(2021,11,04), Id = 4, ShipId = 2, Stars = 3, UserId = "0e40245d-d108-4236-a833-3628e645d097", Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus rutrum arcu sit amet enim euismod, sed mattis quam pellentesque. Proin porttitor ullamcorper euismod. " }
            );
        }

        public new DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Ranking> Rankings { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Ship> Ships { get; set; }
    }
}
