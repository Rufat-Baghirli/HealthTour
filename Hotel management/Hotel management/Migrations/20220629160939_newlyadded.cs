using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class newlyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "SpecialDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OneweekPrice = table.Column<double>(type: "float", nullable: false),
                    TwoweeksPrice = table.Column<double>(type: "float", nullable: false),
                    ThreeweeksPrice = table.Column<double>(type: "float", nullable: false),
                    OneweekPriceMid = table.Column<double>(type: "float", nullable: false),
                    TwoweeksPriceMid = table.Column<double>(type: "float", nullable: false),
                    ThreeweeksPriceMid = table.Column<double>(type: "float", nullable: false),
                    OneweekPriceHigh = table.Column<double>(type: "float", nullable: false),
                    TwoweeksPriceHigh = table.Column<double>(type: "float", nullable: false),
                    ThreeweeksPriceHigh = table.Column<double>(type: "float", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Smoking = table.Column<bool>(type: "bit", nullable: false),
                    Roomarea = table.Column<float>(type: "real", nullable: false),
                    Mainimg = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    People = table.Column<int>(type: "int", nullable: false),
                    Children = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomTypes_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialDays_RoomTypeId",
                table: "SpecialDays",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatures_RoomTypeId",
                table: "RoomFeatures",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_HotelId",
                table: "RoomTypes",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_RoomTypes_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "RoomTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatures_RoomTypes_RoomTypeId",
                table: "RoomFeatures",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomImages_RoomTypes_RoomId",
                table: "RoomImages",
                column: "RoomId",
                principalTable: "RoomTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialDays_RoomTypes_RoomTypeId",
                table: "SpecialDays",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_RoomTypes_RoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatures_RoomTypes_RoomTypeId",
                table: "RoomFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomImages_RoomTypes_RoomId",
                table: "RoomImages");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialDays_RoomTypes_RoomTypeId",
                table: "SpecialDays");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropIndex(
                name: "IX_SpecialDays_RoomTypeId",
                table: "SpecialDays");

            migrationBuilder.DropIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages");

            migrationBuilder.DropIndex(
                name: "IX_RoomFeatures_RoomTypeId",
                table: "RoomFeatures");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "SpecialDays");
        }
    }
}
