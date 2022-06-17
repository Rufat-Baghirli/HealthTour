using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class Pleaseaddthiss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_SiteUserId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_AcceptReservation_AcceptReservationId",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "RoomReserveds");

            migrationBuilder.DropTable(
                name: "AcceptReservation");

            migrationBuilder.DropIndex(
                name: "IX_Guests_AcceptReservationId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_SiteUserId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AcceptReservationId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "SiteUserId1",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "SiteUserId",
                table: "Bookings",
                newName: "HotelId");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Children",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Adults",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelId",
                table: "Bookings",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Hotels_HotelId",
                table: "Bookings",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Hotels_HotelId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_HotelId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Adults");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Bookings",
                newName: "SiteUserId");

            migrationBuilder.AddColumn<int>(
                name: "AcceptReservationId",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteUserId1",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AcceptReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    Checkin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Checkout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    DiscountPercent = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcceptReservation_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomReserveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcceptReservationId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReserveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomReserveds_AcceptReservation_AcceptReservationId",
                        column: x => x.AcceptReservationId,
                        principalTable: "AcceptReservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomReserveds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guests_AcceptReservationId",
                table: "Guests",
                column: "AcceptReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SiteUserId1",
                table: "Bookings",
                column: "SiteUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptReservation_HotelId",
                table: "AcceptReservation",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReserveds_AcceptReservationId",
                table: "RoomReserveds",
                column: "AcceptReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReserveds_RoomId",
                table: "RoomReserveds",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_SiteUserId1",
                table: "Bookings",
                column: "SiteUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_AcceptReservation_AcceptReservationId",
                table: "Guests",
                column: "AcceptReservationId",
                principalTable: "AcceptReservation",
                principalColumn: "Id");
        }
    }
}
