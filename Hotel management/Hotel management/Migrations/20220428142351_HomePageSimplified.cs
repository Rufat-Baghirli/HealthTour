using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class HomePageSimplified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homeflavours");

            migrationBuilder.DropTable(
                name: "HomeHotelRooms");

            migrationBuilder.DropTable(
                name: "HomeHotels");

            migrationBuilder.DropTable(
                name: "HomeMainHotels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homeflavours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    Leftimg = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    Rightimg = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeflavours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeHotelRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccordionText = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    Leftimg = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    Rightimg = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeHotelRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeHotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLeft = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeHotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeMainHotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeMainHotels", x => x.Id);
                });
        }
    }
}
