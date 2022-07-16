using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class alacheckdaaaaaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraPrices_Hotels_HotelId",
                table: "ExtraPrices");

            migrationBuilder.DropIndex(
                name: "IX_ExtraPrices_HotelId",
                table: "ExtraPrices");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "ExtraPrices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraPrices_HotelId",
                table: "ExtraPrices",
                column: "HotelId",
                unique: true,
                filter: "[HotelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraPrices_Hotels_HotelId",
                table: "ExtraPrices",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraPrices_Hotels_HotelId",
                table: "ExtraPrices");

            migrationBuilder.DropIndex(
                name: "IX_ExtraPrices_HotelId",
                table: "ExtraPrices");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "ExtraPrices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExtraPrices_HotelId",
                table: "ExtraPrices",
                column: "HotelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraPrices_Hotels_HotelId",
                table: "ExtraPrices",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
