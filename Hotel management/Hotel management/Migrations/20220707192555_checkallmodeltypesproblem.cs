using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class checkallmodeltypesproblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatureDetails_HotelFeatures_HotelFeatureId",
                table: "RoomFeatureDetails");

            migrationBuilder.DropIndex(
                name: "IX_RoomFeatureDetails_HotelFeatureId",
                table: "RoomFeatureDetails");

            migrationBuilder.DropColumn(
                name: "HotelFeatureId",
                table: "RoomFeatureDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelFeatureId",
                table: "RoomFeatureDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatureDetails_HotelFeatureId",
                table: "RoomFeatureDetails",
                column: "HotelFeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatureDetails_HotelFeatures_HotelFeatureId",
                table: "RoomFeatureDetails",
                column: "HotelFeatureId",
                principalTable: "HotelFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
