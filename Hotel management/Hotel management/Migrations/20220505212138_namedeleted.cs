using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class namedeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_en",
                table: "HotelTranslations");

            migrationBuilder.DropColumn(
                name: "Name_ru",
                table: "HotelTranslations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_en",
                table: "HotelTranslations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_ru",
                table: "HotelTranslations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
