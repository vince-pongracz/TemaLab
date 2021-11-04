using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Server.Data.Migrations
{
    public partial class validation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
