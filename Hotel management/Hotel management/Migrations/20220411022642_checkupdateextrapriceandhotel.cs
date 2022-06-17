using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class checkupdateextrapriceandhotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraPrices_RoomTypes_RoomTypeId",
                table: "ExtraPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_ChildrenDiscounts_ChildDiscountId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "ChildrenDiscounts");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_ChildDiscountId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "ChildDiscountId",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "RoomTypeId",
                table: "ExtraPrices",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraPrices_RoomTypeId",
                table: "ExtraPrices",
                newName: "IX_ExtraPrices_HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraPrices_Hotels_HotelId",
                table: "ExtraPrices",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraPrices_Hotels_HotelId",
                table: "ExtraPrices");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "ExtraPrices",
                newName: "RoomTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraPrices_HotelId",
                table: "ExtraPrices",
                newName: "IX_ExtraPrices_RoomTypeId");

            migrationBuilder.AddColumn<int>(
                name: "ChildDiscountId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChildrenDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Babydiscount = table.Column<float>(type: "real", nullable: true),
                    Childrendiscount = table.Column<float>(type: "real", nullable: true),
                    Youngdiscount = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_ChildDiscountId",
                table: "Hotels",
                column: "ChildDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_BookingId",
                table: "Guests",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraPrices_RoomTypes_RoomTypeId",
                table: "ExtraPrices",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_ChildrenDiscounts_ChildDiscountId",
                table: "Hotels",
                column: "ChildDiscountId",
                principalTable: "ChildrenDiscounts",
                principalColumn: "Id");
        }
    }
}
