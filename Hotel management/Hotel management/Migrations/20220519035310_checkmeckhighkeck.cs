using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class checkmeckhighkeck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HighSeasonId",
                table: "Months",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Months_HighSeasonId",
                table: "Months",
                column: "HighSeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Months_HighSeasons_HighSeasonId",
                table: "Months",
                column: "HighSeasonId",
                principalTable: "HighSeasons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Months_HighSeasons_HighSeasonId",
                table: "Months");

            migrationBuilder.DropIndex(
                name: "IX_Months_HighSeasonId",
                table: "Months");

            migrationBuilder.DropColumn(
                name: "HighSeasonId",
                table: "Months");
        }
    }
}
