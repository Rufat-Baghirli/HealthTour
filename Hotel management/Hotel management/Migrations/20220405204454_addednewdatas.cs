using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class addednewdatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BookingContacts_BookingContactId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingContacts");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingContactId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "BookingContactId",
                table: "Bookings",
                newName: "Night");

            migrationBuilder.AddColumn<int>(
                name: "Adult",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Child",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Guest",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReserveTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adult",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Child",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Guest",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ReserveTime",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Night",
                table: "Bookings",
                newName: "BookingContactId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingContactId",
                table: "Bookings",
                column: "BookingContactId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BookingContacts_BookingContactId",
                table: "Bookings",
                column: "BookingContactId",
                principalTable: "BookingContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
