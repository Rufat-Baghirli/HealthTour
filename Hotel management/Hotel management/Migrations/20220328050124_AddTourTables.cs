using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class AddTourTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Mainimg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourDetails_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ekskursiyalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descreption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ekskursiyalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ekskursiyalar_TourDetails_TourDetailsId",
                        column: x => x.TourDetailsId,
                        principalTable: "TourDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qiymetdenkenar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qiymetdenkenar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qiymetdenkenar_TourDetails_TourDetailsId",
                        column: x => x.TourDetailsId,
                        principalTable: "TourDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tourimages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourimages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tourimages_TourDetails_TourDetailsId",
                        column: x => x.TourDetailsId,
                        principalTable: "TourDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    People = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurContacts_TourDetails_TourDetailsId",
                        column: x => x.TourDetailsId,
                        principalTable: "TourDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurXidmətləri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurXidmətləri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurXidmətləri_TourDetails_TourDetailsId",
                        column: x => x.TourDetailsId,
                        principalTable: "TourDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usaqlarucun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usaqlarucun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usaqlarucun_TourDetails_TourDetailsId",
                        column: x => x.TourDetailsId,
                        principalTable: "TourDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ekskursiyalar_TourDetailsId",
                table: "Ekskursiyalar",
                column: "TourDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Qiymetdenkenar_TourDetailsId",
                table: "Qiymetdenkenar",
                column: "TourDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TourDetails_TourId",
                table: "TourDetails",
                column: "TourId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tourimages_TourDetailsId",
                table: "Tourimages",
                column: "TourDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TurContacts_TourDetailsId",
                table: "TurContacts",
                column: "TourDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TurXidmətləri_TourDetailsId",
                table: "TurXidmətləri",
                column: "TourDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Usaqlarucun_TourDetailsId",
                table: "Usaqlarucun",
                column: "TourDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ekskursiyalar");

            migrationBuilder.DropTable(
                name: "Qiymetdenkenar");

            migrationBuilder.DropTable(
                name: "Tourimages");

            migrationBuilder.DropTable(
                name: "TurContacts");

            migrationBuilder.DropTable(
                name: "TurXidmətləri");

            migrationBuilder.DropTable(
                name: "Usaqlarucun");

            migrationBuilder.DropTable(
                name: "TourDetails");
        }
    }
}
