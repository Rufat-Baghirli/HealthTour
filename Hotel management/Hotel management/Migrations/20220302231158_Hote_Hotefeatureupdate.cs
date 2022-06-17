using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class Hote_Hotefeatureupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatures_HotelId",
                table: "HotelFeatures",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelFeatures_Hotels_HotelId",
                table: "HotelFeatures",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelFeatures_Hotels_HotelId",
                table: "HotelFeatures");

            migrationBuilder.DropIndex(
                name: "IX_HotelFeatures_HotelId",
                table: "HotelFeatures");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelFeatures");
        }
    }
}
