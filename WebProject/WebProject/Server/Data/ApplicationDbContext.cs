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
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
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
                new Ship { Id = 1, Caution = 50000, Description = "it's a ship", Draught = 5, HomePort = "Balatonfured", IsAvailable = true, IsDeleted = false, Length = 12, Manufacturer = "ship.kft", Name = "Carol", MaxPeople = 5, PriceAtWeekDays = 10000, PriceAtWeekEnds = 12000, ProductionYear = 2005, ShipType = "fancy", Weight = 2600, Width = 5 },
                new Ship { Id = 2, Caution = 80000, Description = "it's a ship", Draught = 6, HomePort = "Sopron", IsAvailable = true, IsDeleted = false, Length = 15, Manufacturer = "ship2.kft", Name = "Awesome", MaxPeople = 7, PriceAtWeekDays = 20000, PriceAtWeekEnds = 22000, ProductionYear = 2010, ShipType = "very fancy", Weight = 3600, Width = 7 }
            );

            modelBuilder.Entity<Ranking>().HasData(
                new Ranking { Id = 1, Date = new DateTime(2021, 01, 02), Comment = "fhjfghjfghj", Stars = 4},
                new Ranking { Id = 2, Date = new DateTime(2021, 01, 05), Comment = "fhjfghjfghj", Stars = 5},
                new Ranking { Id = 3, Date = new DateTime(2021, 01, 08), Comment = "fhjfghjfghj", Stars = 1},
                new Ranking { Id = 4, Date = new DateTime(2021, 01, 09), Comment = "fhjfghjfghj", Stars = 3},
                new Ranking { Id = 5, Date = new DateTime(2021, 01, 11), Comment = "fhjfghjfghj", Stars = 4},
                new Ranking { Id = 6, Date = new DateTime(2021, 01, 22), Comment = "fhjfghjfghj", Stars = 5}
            );

            //TODO PV ez reflexiv kell, vagyis oda vissza irányokba kell a binding?
            //Reservation bindings
            modelBuilder.Entity<Reservation>().HasOne(r => r.Ship).WithMany(s => s.Reservations);
            modelBuilder.Entity<Reservation>().HasOne(u => u.Person).WithMany(r => r.Reservations);

            //User bindings
            modelBuilder.Entity<ApplicationUser>().HasMany(s => s.OwnedShips).WithOne(u => u.Owner);
            modelBuilder.Entity<ApplicationUser>().HasMany(r => r.Rankings).WithOne(u => u.Person);
            modelBuilder.Entity<ApplicationUser>().HasMany(res => res.Reservations).WithOne(u => u.Person);

            //Ranking bindings
            modelBuilder.Entity<Ranking>().HasOne(s => s.Ship).WithMany(r => r.Rankings);
            modelBuilder.Entity<Ranking>().HasOne(u => u.Person).WithMany(r => r.Rankings);

            //Ship binding
            modelBuilder.Entity<Ship>().HasMany(res => res.Reservations).WithOne(s => s.Ship);
            modelBuilder.Entity<Ship>().HasOne(u => u.Owner).WithMany(s => s.OwnedShips);
            modelBuilder.Entity<Ship>().HasMany(r => r.Rankings).WithOne(s => s.Ship);

        }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Ranking> Rankings { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Ship> Ships { get; set; }
    }
}
