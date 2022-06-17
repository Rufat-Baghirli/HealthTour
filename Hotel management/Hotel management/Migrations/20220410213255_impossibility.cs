using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class impossibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Children",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Adults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Children_BookingId",
                table: "Children",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Adults_BookingId",
                table: "Adults",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Bookings_BookingId",
                table: "Adults",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Bookings_BookingId",
                table: "Children",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Bookings_BookingId",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Bookings_BookingId",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_BookingId",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Adults_BookingId",
                table: "Adults");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Adults");
        }
    }
}
