using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class Seasonprices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OneweekPriceHigh",
                table: "RoomTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OneweekPriceMid",
                table: "RoomTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ThreeweeksPriceHigh",
                table: "RoomTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ThreeweeksPriceMid",
                table: "RoomTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TwoweeksPriceHigh",
                table: "RoomTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TwoweeksPriceMid",
                table: "RoomTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OneweekPriceHigh",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "OneweekPriceMid",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "ThreeweeksPriceHigh",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "ThreeweeksPriceMid",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "TwoweeksPriceHigh",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "TwoweeksPriceMid",
                table: "RoomTypes");
        }
    }
}
