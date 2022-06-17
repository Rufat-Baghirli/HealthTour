using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class AddedTranslationModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelFeatureId",
                table: "RoomFeatureDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ForeignDomesticTourTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeignTourDescription_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForeignTourDescription_ru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomesticTourDescription_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomesticTourDescription_ru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForeignDomesticTourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignDomesticTourTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignDomesticTourTranslations_ForeignDomesticTours_ForeignDomesticTourId",
                        column: x => x.ForeignDomesticTourId,
                        principalTable: "ForeignDomesticTours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatureDetailsTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail_ru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelFeatureDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatureDetailsTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeatureDetailsTranslations_HotelFeatureDetails_HotelFeatureDetailsId",
                        column: x => x.HotelFeatureDetailsId,
                        principalTable: "HotelFeatureDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatureTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_ru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelFeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatureTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeatureTranslations_HotelFeatures_HotelFeatureId",
                        column: x => x.HotelFeatureId,
                        principalTable: "HotelFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomFeatureDetailTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail_ru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomFeatureDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeatureDetailTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFeatureDetailTranslations_RoomFeatureDetails_RoomFeatureDetailId",
                        column: x => x.RoomFeatureDetailId,
                        principalTable: "RoomFeatureDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomFeaturesTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Features_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Features_ru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomFeaturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeaturesTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFeaturesTranslation_RoomFeatures_RoomFeaturesId",
                        column: x => x.RoomFeaturesId,
                        principalTable: "RoomFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_en = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name_ru = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description_en = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description_ru = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourTranslations_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_en = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name_ru = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description_ru = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentTranslations_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatureDetails_HotelFeatureId",
                table: "RoomFeatureDetails",
                column: "HotelFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignDomesticTourTranslations_ForeignDomesticTourId",
                table: "ForeignDomesticTourTranslations",
                column: "ForeignDomesticTourId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatureDetailsTranslations_HotelFeatureDetailsId",
                table: "HotelFeatureDetailsTranslations",
                column: "HotelFeatureDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatureTranslations_HotelFeatureId",
                table: "HotelFeatureTranslations",
                column: "HotelFeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatureDetailTranslations_RoomFeatureDetailId",
                table: "RoomFeatureDetailTranslations",
                column: "RoomFeatureDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeaturesTranslation_RoomFeaturesId",
                table: "RoomFeaturesTranslation",
                column: "RoomFeaturesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourTranslations_TourId",
                table: "TourTranslations",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentTranslations_TreatmentId",
                table: "TreatmentTranslations",
                column: "TreatmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatureDetails_HotelFeatures_HotelFeatureId",
                table: "RoomFeatureDetails",
                column: "HotelFeatureId",
                principalTable: "HotelFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatureDetails_HotelFeatures_HotelFeatureId",
                table: "RoomFeatureDetails");

            migrationBuilder.DropTable(
                name: "ForeignDomesticTourTranslations");

            migrationBuilder.DropTable(
                name: "HotelFeatureDetailsTranslations");

            migrationBuilder.DropTable(
                name: "HotelFeatureTranslations");

            migrationBuilder.DropTable(
                name: "RoomFeatureDetailTranslations");

            migrationBuilder.DropTable(
                name: "RoomFeaturesTranslation");

            migrationBuilder.DropTable(
                name: "TourTranslations");

            migrationBuilder.DropTable(
                name: "TreatmentTranslations");

            migrationBuilder.DropIndex(
                name: "IX_RoomFeatureDetails_HotelFeatureId",
                table: "RoomFeatureDetails");

            migrationBuilder.DropColumn(
                name: "HotelFeatureId",
                table: "RoomFeatureDetails");
        }
    }
}
