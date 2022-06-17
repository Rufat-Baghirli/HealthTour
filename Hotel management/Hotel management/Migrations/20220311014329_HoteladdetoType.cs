using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class HoteladdetoType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "RoomTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_HotelId",
                table: "RoomTypes",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypes_Hotels_HotelId",
                table: "RoomTypes",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypes_Hotels_HotelId",
                table: "RoomTypes");

            migrationBuilder.DropIndex(
                name: "IX_RoomTypes_HotelId",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "RoomTypes");
        }
    }
}
