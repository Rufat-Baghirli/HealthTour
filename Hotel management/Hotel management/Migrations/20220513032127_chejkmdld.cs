using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class chejkmdld : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TourTranslations_TourId",
                table: "TourTranslations");

            migrationBuilder.CreateIndex(
                name: "IX_TourTranslations_TourId",
                table: "TourTranslations",
                column: "TourId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TourTranslations_TourId",
                table: "TourTranslations");

            migrationBuilder.CreateIndex(
                name: "IX_TourTranslations_TourId",
                table: "TourTranslations",
                column: "TourId");
        }
    }
}
