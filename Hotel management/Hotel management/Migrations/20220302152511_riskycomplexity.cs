using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class riskycomplexity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatureDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelFeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatureDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeatureDetails_HotelFeatures_HotelFeatureId",
                        column: x => x.HotelFeatureId,
                        principalTable: "HotelFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatureDetails_HotelFeatureId",
                table: "HotelFeatureDetails",
                column: "HotelFeatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelFeatureDetails");

            migrationBuilder.DropTable(
                name: "HotelFeatures");
        }
    }
}
