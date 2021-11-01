using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Server.Data.Migrations
{
    public partial class SeedRankings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rankings",
                columns: new[] { "Id", "Comment", "Date", "PersonId", "ShipId", "Stars" },
                values: new object[,]
                {
                    { 1, "fhjfghjfghj", new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4 },
                    { 2, "fhjfghjfghj", new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5 },
                    { 3, "fhjfghjfghj", new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 },
                    { 4, "fhjfghjfghj", new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3 },
                    { 5, "fhjfghjfghj", new DateTime(2021, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4 },
                    { 6, "fhjfghjfghj", new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5 }
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
                table: "Rankings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rankings",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
