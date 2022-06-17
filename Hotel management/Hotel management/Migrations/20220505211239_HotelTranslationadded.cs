using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class HotelTranslationadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_ru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_ru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelTranslations_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelTranslations_HotelId",
                table: "HotelTranslations",
                column: "HotelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelTranslations");
        }
    }
}
