﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProject.Server.Data;

namespace WebProject.Server.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebProject.Server.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FacebookLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebProject.Server.Models.Ranking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ShipId")
                        .HasColumnType("int");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ShipId");

                    b.ToTable("Rankings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "fhjfghjfghj",
                            Date = new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stars = 4
                        },
                        new
                        {
                            Id = 2,
                            Comment = "fhjfghjfghj",
                            Date = new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stars = 5
                        },
                        new
                        {
                            Id = 3,
                            Comment = "fhjfghjfghj",
                            Date = new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stars = 1
                        },
                        new
                        {
                            Id = 4,
                            Comment = "fhjfghjfghj",
                            Date = new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stars = 3
                        },
                        new
                        {
                            Id = 5,
                            Comment = "fhjfghjfghj",
                            Date = new DateTime(2021, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stars = 4
                        },
                        new
                        {
                            Id = 6,
                            Comment = "fhjfghjfghj",
                            Date = new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stars = 5
                        });
                });

            modelBuilder.Entity("WebProject.Server.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ShipId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ShipId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FromDate = new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 50000m,
                            ToDate = new DateTime(2021, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            FromDate = new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 70000m,
                            ToDate = new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("WebProject.Server.Models.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Caution")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<double>("Draught")
                        .HasColumnType("float");

                    b.Property<string>("HomePort")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("MaxPeople")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("PriceAtWeekDays")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceAtWeekEnds")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<string>("RouteToPic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipType")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Ships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Caution = 50000m,
                            Description = "it's a ship",
                            Draught = 5.0,
                            HomePort = "Balatonfured",
                            IsAvailable = true,
                            IsDeleted = false,
                            Length = 12.0,
                            Manufacturer = "ship.kft",
                            MaxPeople = 5,
                            Name = "Carol",
                            PriceAtWeekDays = 10000m,
                            PriceAtWeekEnds = 12000m,
                            ProductionYear = 2005,
                            ShipType = "fancy",
                            Weight = 2600.0,
                            Width = 5.0
                        },
                        new
                        {
                            Id = 2,
                            Caution = 80000m,
                            Description = "it's a ship",
                            Draught = 6.0,
                            HomePort = "Sopron",
                            IsAvailable = true,
                            IsDeleted = false,
                            Length = 15.0,
                            Manufacturer = "ship2.kft",
                            MaxPeople = 7,
                            Name = "Awesome",
                            PriceAtWeekDays = 20000m,
                            PriceAtWeekEnds = 22000m,
                            ProductionYear = 2010,
                            ShipType = "very fancy",
                            Weight = 3600.0,
                            Width = 7.0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebProject.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebProject.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProject.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebProject.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebProject.Server.Models.Ranking", b =>
                {
                    b.HasOne("WebProject.Server.Models.ApplicationUser", "Person")
                        .WithMany("Rankings")
                        .HasForeignKey("PersonId");

                    b.HasOne("WebProject.Server.Models.Ship", "Ship")
                        .WithMany("Rankings")
                        .HasForeignKey("ShipId");

                    b.Navigation("Person");

                    b.Navigation("Ship");
                });

            modelBuilder.Entity("WebProject.Server.Models.Reservation", b =>
                {
                    b.HasOne("WebProject.Server.Models.ApplicationUser", "Person")
                        .WithMany("Reservations")
                        .HasForeignKey("PersonId");

                    b.HasOne("WebProject.Server.Models.Ship", "Ship")
                        .WithMany("Reservations")
                        .HasForeignKey("ShipId");

                    b.Navigation("Person");

                    b.Navigation("Ship");
                });

            modelBuilder.Entity("WebProject.Server.Models.Ship", b =>
                {
                    b.HasOne("WebProject.Server.Models.ApplicationUser", "Owner")
                        .WithMany("OwnedShips")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("WebProject.Server.Models.ApplicationUser", b =>
                {
                    b.Navigation("OwnedShips");

                    b.Navigation("Rankings");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("WebProject.Server.Models.Ship", b =>
                {
                    b.Navigation("Rankings");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
