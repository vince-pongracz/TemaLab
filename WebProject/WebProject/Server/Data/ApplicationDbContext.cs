using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Server.Models;

namespace WebProject.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options,IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { Id = 1, FromDate = new DateTime(2021, 10, 16), Price = 50000, ToDate = new DateTime(2021, 10, 18) },
                new Reservation { Id = 2, FromDate = new DateTime(2021, 9, 16), Price = 70000, ToDate = new DateTime(2021, 9, 18) }
            );

            modelBuilder.Entity<Ship>().HasData(
                new Ship { Id = 1, Caution = 50000, Description = "it's a ship", Drought = 5, HomePort = "Balatonfured", IsAvailable = true, IsDeleted = false, Lenght = 12, Manufacturer = "ship.kft", Name = "Carol", PersonsMax = 5, PriceAtWeekDays = 10000, PriceAtWeekEnds = 12000, ProductionYear = 2005, ShipType = "fancy", Weight = 2600, Width = 5 },
                new Ship { Id = 2, Caution = 80000, Description = "it's a ship", Drought = 6, HomePort = "Sopron", IsAvailable = true, IsDeleted = false, Lenght = 15, Manufacturer = "ship2.kft", Name = "Awesome", PersonsMax = 7, PriceAtWeekDays = 20000, PriceAtWeekEnds = 22000, ProductionYear = 2010, ShipType = "very fancy", Weight = 3600, Width = 7 }
            );

            modelBuilder.Entity<Reservation>() //TODO ilyenből még kell a többi is
                .HasOne(r => r.Ship)
                .WithMany(s => s.Reservations);
        }

        public DbSet<ApplicationUser>  Users { get; set; } 

        public DbSet<Ranking> Rankings { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Ship> Ships { get; set; }
    }
}
