using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class somechildadultchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WithTreatment",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "Withtreatment",
                table: "Adults");

            migrationBuilder.RenameColumn(
                name: "GuidId",
                table: "Children",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GuidId",
                table: "Adults",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Children",
                newName: "GuidId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Adults",
                newName: "GuidId");

            migrationBuilder.AddColumn<bool>(
                name: "WithTreatment",
                table: "Children",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Withtreatment",
                table: "Adults",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
