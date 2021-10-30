using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Server.Data.Migrations
{
    public partial class shipExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouteToPic",
                table: "Ships",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteToPic",
                table: "Ships");
        }
    }
}
