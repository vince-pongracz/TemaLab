using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Server.Data.Migrations
{
    public partial class validation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShipType",
                table: "Ships",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ships",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Ships",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomePort",
                table: "Ships",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ships",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Drought", "Lenght", "PersonsMax" },
                values: new object[] { 5.0, 12.0, 5 });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Drought", "Lenght", "PersonsMax" },
                values: new object[] { 6.0, 15.0, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Drought",
                table: "Rankings",
                newName: "Drought");

            migrationBuilder.RenameColumn(
                            name: "Lenght",
                            table: "Rankings",
                            newName: "Lenght");

            migrationBuilder.RenameColumn(
                name: "PersonsMax",
                table: "Rankings",
                newName: "PersonsMax");

            migrationBuilder.AlterColumn<string>(
                name: "ShipType",
                table: "Ships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Ships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomePort",
                table: "Ships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Drought", "Lenght", "PersonsMax" },
                values: new object[] { 0.0, 0.0, 0 });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Drought", "Lenght", "PersonsMax" },
                values: new object[] { 0.0, 0.0, 0 });
        }
    }
}
