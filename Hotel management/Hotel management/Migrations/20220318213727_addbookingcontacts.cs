using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class addbookingcontacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Mobilenumber",
                table: "Guests");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookingContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Checkin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Checkout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiteUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SiteUserId = table.Column<int>(type: "int", nullable: false),
                    BookingContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_SiteUserId1",
                        column: x => x.SiteUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_BookingContacts_BookingContactId",
                        column: x => x.BookingContactId,
                        principalTable: "BookingContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guests_BookingId",
                table: "Guests",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingContactId",
                table: "Bookings",
                column: "BookingContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SiteUserId1",
                table: "Bookings",
                column: "SiteUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Bookings_BookingId",
                table: "Guests",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Bookings_BookingId",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingContacts");

            migrationBuilder.DropIndex(
                name: "IX_Guests_BookingId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Guests");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mobilenumber",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
