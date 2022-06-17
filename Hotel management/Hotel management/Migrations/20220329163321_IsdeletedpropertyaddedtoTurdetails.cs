using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class IsdeletedpropertyaddedtoTurdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TourDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TourDetails");
        }
    }
}
