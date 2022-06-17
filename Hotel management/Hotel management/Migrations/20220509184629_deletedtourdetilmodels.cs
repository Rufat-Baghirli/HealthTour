using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class deletedtourdetilmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TurContacts_TourDetails_TourDetailsId",
                table: "TurContacts");

            migrationBuilder.DropTable(
                name: "Ekskursiyalar");

            migrationBuilder.DropTable(
                name: "Qiymetdenkenar");

            migrationBuilder.DropTable(
                name: "TurHotels");

            migrationBuilder.DropTable(
                name: "TurXidmətləri");

            migrationBuilder.DropTable(
                name: "Usaqlarucun");

            migrationBuilder.DropTable(
                name: "TourDetails");

            migrationBuilder.DropIndex(
                name: "IX_TurContacts_TourDetailsId",
                table: "TurContacts");

            migrationBuilder.DropColumn(
                name: "TourDetailsId",
                table: "TurContacts");

            migrationBuilder.RenameColumn(
                name: "People",
                table: "TurContacts",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "TurContacts",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "TurContacts",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TurContacts",
                newName: "Location");

            migrationBuilder.AddColumn<int>(
                name: "TourDetailsId",
                table: "TurContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TourDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Mainimg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    TourDetailsId = table.Column<int>(type: "int", nullable: false),
                    Descreption = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    TourDetailsId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "TurHotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourDetailsId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurHotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurHotels_TourDetails_TourDetailsId",
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
                    TourDetailsId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    TourDetailsId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_TurContacts_TourDetailsId",
                table: "TurContacts",
                column: "TourDetailsId",
                unique: true);

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
                name: "IX_TurHotels_TourDetailsId",
                table: "TurHotels",
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

            migrationBuilder.AddForeignKey(
                name: "FK_TurContacts_TourDetails_TourDetailsId",
                table: "TurContacts",
                column: "TourDetailsId",
                principalTable: "TourDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
