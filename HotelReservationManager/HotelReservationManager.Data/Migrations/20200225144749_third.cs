using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationManager.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserMadeReservationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserMadeReservationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserMadeReservationId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "HotelUserId",
                table: "Reservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelUserId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "UserMadeReservationId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserMadeReservationId",
                table: "Reservations",
                column: "UserMadeReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserMadeReservationId",
                table: "Reservations",
                column: "UserMadeReservationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
