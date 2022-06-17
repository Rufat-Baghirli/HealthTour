using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class extrapriceupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BabyPricewithtreatment",
                table: "ExtraPrices");

            migrationBuilder.DropColumn(
                name: "ChildPricewithtreatment",
                table: "ExtraPrices");

            migrationBuilder.DropColumn(
                name: "YoungPricewithtreatment",
                table: "ExtraPrices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "BabyPricewithtreatment",
                table: "ExtraPrices",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ChildPricewithtreatment",
                table: "ExtraPrices",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "YoungPricewithtreatment",
                table: "ExtraPrices",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
