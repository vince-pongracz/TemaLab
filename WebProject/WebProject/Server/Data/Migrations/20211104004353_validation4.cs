using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Server.Data.Migrations
{
    public partial class validation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonsMax",
                table: "Ships",
                newName: "MaxPeople");

            migrationBuilder.RenameColumn(
                name: "Lenght",
                table: "Ships",
                newName: "Length");

            migrationBuilder.RenameColumn(
                name: "Drought",
                table: "Ships",
                newName: "Draught");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxPeople",
                table: "Ships",
                newName: "PersonsMax");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Ships",
                newName: "Lenght");

            migrationBuilder.RenameColumn(
                name: "Draught",
                table: "Ships",
                newName: "Drought");
        }
    }
}
