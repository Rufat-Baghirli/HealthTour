using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class updatetransfermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVip",
                table: "Transfers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVip",
                table: "Transfers");
        }
    }
}
