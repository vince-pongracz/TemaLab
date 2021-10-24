using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Server.Data.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Ships");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Rankings",
                newName: "PersonId");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Ships",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShipId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PersonId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShipId",
                table: "Rankings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PersonId",
                table: "Rankings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "FromDate", "PersonId", "Price", "ShipId", "ToDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50000m, null, new DateTime(2021, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 70000m, null, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Caution", "Description", "Drought", "HomePort", "IsAvailable", "IsDeleted", "Lenght", "Manufacturer", "Name", "OwnerId", "PersonsMax", "PriceAtWeekDays", "PriceAtWeekEnds", "ProductionYear", "ShipType", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, 50000m, "it's a ship", 5.0, "Balatonfured", true, false, 12.0, "ship.kft", "Carol", null, 5, 10000m, 12000m, 2005, "fancy", 2600.0, 5.0 },
                    { 2, 80000m, "it's a ship", 6.0, "Sopron", true, false, 15.0, "ship2.kft", "Awesome", null, 7, 20000m, 22000m, 2010, "very fancy", 3600.0, 7.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ships_OwnerId",
                table: "Ships",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PersonId",
                table: "Reservations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ShipId",
                table: "Reservations",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_PersonId",
                table: "Rankings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rankings_ShipId",
                table: "Rankings",
                column: "ShipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rankings_AspNetUsers_PersonId",
                table: "Rankings",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rankings_Ships_ShipId",
                table: "Rankings",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_PersonId",
                table: "Reservations",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Ships_ShipId",
                table: "Reservations",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_AspNetUsers_OwnerId",
                table: "Ships",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rankings_AspNetUsers_PersonId",
                table: "Rankings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rankings_Ships_ShipId",
                table: "Rankings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_PersonId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Ships_ShipId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_AspNetUsers_OwnerId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_OwnerId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PersonId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ShipId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Rankings_PersonId",
                table: "Rankings");

            migrationBuilder.DropIndex(
                name: "IX_Rankings_ShipId",
                table: "Rankings");

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Ships");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Rankings",
                newName: "PersonID");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ShipId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShipId",
                table: "Rankings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Rankings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
