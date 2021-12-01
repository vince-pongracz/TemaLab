using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Server.Migrations
{
    public partial class ApproveReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReservationApproved",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationApproved",
                table: "Reservations");
        }
    }
}
