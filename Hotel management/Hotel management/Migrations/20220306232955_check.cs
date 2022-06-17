using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "BedCount",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "BedRoom",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "Bedtype",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "TreatmentDescription",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "TreatmentPrice",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "MinArea",
                table: "RoomTypes",
                newName: "TwoweeksPrice");

            migrationBuilder.RenameColumn(
                name: "MaxArea",
                table: "RoomTypes",
                newName: "ThreeweeksPrice");

            migrationBuilder.AddColumn<double>(
                name: "OneweekPrice",
                table: "RoomTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "isDiscount",
                table: "RoomTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Mainimg",
                table: "Rooms",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExtraPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BabyPricewithtreatment = table.Column<float>(type: "real", nullable: false),
                    BabyPrice = table.Column<float>(type: "real", nullable: false),
                    ChildPricewithtreatment = table.Column<float>(type: "real", nullable: false),
                    ChildPrice = table.Column<float>(type: "real", nullable: false),
                    YoungPricewithtreatment = table.Column<float>(type: "real", nullable: false),
                    YoungPrice = table.Column<float>(type: "real", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraPrices_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraPrices_RoomTypeId",
                table: "ExtraPrices",
                column: "RoomTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_HotelId",
                table: "Treatments",
                column: "HotelId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Rooms_Hotels_HotelId",
            //    table: "Rooms",
            //    column: "HotelId",
            //    principalTable: "Hotels",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "ExtraPrices");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropColumn(
                name: "OneweekPrice",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "isDiscount",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "TwoweeksPrice",
                table: "RoomTypes",
                newName: "MinArea");

            migrationBuilder.RenameColumn(
                name: "ThreeweeksPrice",
                table: "RoomTypes",
                newName: "MaxArea");

            migrationBuilder.AddColumn<int>(
                name: "BedCount",
                table: "RoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BedRoom",
                table: "RoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Bedtype",
                table: "RoomTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mainimg",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TreatmentDescription",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TreatmentPrice",
                table: "Hotels",
                type: "float",
                nullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Rooms_Hotels_HotelId",
            //    table: "Rooms",
            //    column: "HotelId",
            //    principalTable: "Hotels",
            //    principalColumn: "Id");
        }
    }
}
