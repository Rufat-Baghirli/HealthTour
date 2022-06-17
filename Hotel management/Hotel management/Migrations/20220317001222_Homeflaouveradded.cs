using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class Homeflaouveradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homeflavours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    Leftimg = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    Rightimg = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeflavours", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homeflavours");
        }
    }
}
