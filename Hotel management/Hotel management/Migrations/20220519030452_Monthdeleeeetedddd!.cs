using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class Monthdeleeeetedddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Months");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HighSeasonId = table.Column<int>(type: "int", nullable: true),
                    LowSeasonId = table.Column<int>(type: "int", nullable: true),
                    MidSeasonId = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Months_HighSeasons_HighSeasonId",
                        column: x => x.HighSeasonId,
                        principalTable: "HighSeasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Months_LowSeasons_LowSeasonId",
                        column: x => x.LowSeasonId,
                        principalTable: "LowSeasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Months_MidSeasons_MidSeasonId",
                        column: x => x.MidSeasonId,
                        principalTable: "MidSeasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Months_HighSeasonId",
                table: "Months",
                column: "HighSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Months_LowSeasonId",
                table: "Months",
                column: "LowSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Months_MidSeasonId",
                table: "Months",
                column: "MidSeasonId");
        }
    }
}
