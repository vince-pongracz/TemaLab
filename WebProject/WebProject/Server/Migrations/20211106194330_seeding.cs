using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Server.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Caution", "Description", "Draught", "HomePort", "IsAvailable", "IsDeleted", "Length", "Manufacturer", "MaxPeople", "Name", "OwnerId", "PriceAtWeekDays", "PriceAtWeekEnds", "ProductionYear", "RouteToPic", "ShipType", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, 555555m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus rutrum arcu sit amet enim euismod, sed mattis quam pellentesque....", 15.0, "Sopron", true, false, 10.0, "ship.kft", 10, "Carol", "0e40245d-d108-4236-a833-3628e645d097", 10000m, 12000m, 1999, null, "fancy", 1500.0, 5.0 },
                    { 2, 555555m, "Mauris dui nisl, suscipit id fringilla id, efficitur sed erat...", 15.0, "Balatonfüred", true, false, 10.0, "ship.kft", 5, "Awesome", "0e40245d-d108-4236-a833-3628e645d097", 20000m, 22000m, 1999, null, "fancy", 1500.0, 5.0 },
                    { 3, 555555m, "Ut sit amet tellus eu elit egestas tempor. Sed ut tortor malesuada, posuere leo non, hendrerit turpis. ...", 15.0, "Tisza-tó", true, false, 10.0, "ship.kft", 12, "Jazz", "0e40245d-d108-4236-a833-3628e645d097", 30000m, 32000m, 1999, null, "fancy", 1500.0, 5.0 },
                    { 4, 555555m, "Etiam eu eros id turpis volutpat mollis sed vitae metus. Ut suscipit lectus enim...", 15.0, "Velencei-tó", true, false, 10.0, "ship.kft", 14, "Sina", "0e40245d-d108-4236-a833-3628e645d097", 40000m, 42000m, 1999, null, "fancy", 1500.0, 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Rankings",
                columns: new[] { "Id", "Comment", "Date", "ShipId", "Stars", "UserId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus rutrum arcu sit amet enim euismod, sed mattis quam pellentesque. Proin porttitor ullamcorper euismod. ", new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, "0e40245d-d108-4236-a833-3628e645d097" },
                    { 2, "Nulla ut odio sem. Donec convallis, arcu ac convallis posuere, ipsum ligula dapibus neque, ullamcorper vulputate nunc ipsum in enim. Aliquam finibus quam vitae justo tincidunt, eu viverra diam suscipit. Donec sodales at enim sollicitudin dignissim. Praesent aliquam venenatis nulla, et pulvinar massa ullamcorper et. ", new DateTime(2021, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, "0e40245d-d108-4236-a833-3628e645d097" },
                    { 3, "Ut sit amet tellus eu elit egestas tempor. Sed ut tortor malesuada, posuere leo non, hendrerit turpis. Nam imperdiet tincidunt ultricies. Nulla sit amet est a velit ornare aliquet. ", new DateTime(2021, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "0e40245d-d108-4236-a833-3628e645d097" },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus rutrum arcu sit amet enim euismod, sed mattis quam pellentesque. Proin porttitor ullamcorper euismod. ", new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, "0e40245d-d108-4236-a833-3628e645d097" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "ApplicationUserId", "FromDate", "Price", "ShipId", "ToDate" },
                values: new object[,]
                {
                    { 1, "0e40245d-d108-4236-a833-3628e645d097", new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 55555m, 1, new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "0e40245d-d108-4236-a833-3628e645d097", new DateTime(2021, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 66666m, 2, new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "0e40245d-d108-4236-a833-3628e645d097", new DateTime(2021, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 77777m, 3, new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "0e40245d-d108-4236-a833-3628e645d097", new DateTime(2021, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 88888m, 4, new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rankings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rankings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rankings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rankings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
