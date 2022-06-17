using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class season : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HighSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HighSeasons_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LowSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LowSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LowSeasons_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MidSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MidSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MidSeasons_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HighSeasonId = table.Column<int>(type: "int", nullable: true),
                    LowSeasonId = table.Column<int>(type: "int", nullable: true),
                    MidSeasonId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_HighSeasons_SeasonId",
                table: "HighSeasons",
                column: "SeasonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LowSeasons_SeasonId",
                table: "LowSeasons",
                column: "SeasonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MidSeasons_SeasonId",
                table: "MidSeasons",
                column: "SeasonId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_HotelId",
                table: "Seasons",
                column: "HotelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropTable(
                name: "HighSeasons");

            migrationBuilder.DropTable(
                name: "LowSeasons");

            migrationBuilder.DropTable(
                name: "MidSeasons");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
