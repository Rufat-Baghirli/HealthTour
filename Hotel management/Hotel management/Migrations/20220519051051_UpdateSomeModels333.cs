using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class UpdateSomeModels333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.AddColumn<bool>(
                name: "April",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "August",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "December",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "February",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "January",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "July",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "June",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "March",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "May",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "November",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "October",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "September",
                table: "MidSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "April",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "August",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "December",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "February",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "January",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "July",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "June",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "March",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "May",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "November",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "October",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "September",
                table: "LowSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "April",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "August",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "December",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "February",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "January",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "July",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "June",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "March",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "May",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "November",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "October",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "September",
                table: "HighSeasons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "April",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "August",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "December",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "February",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "January",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "July",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "June",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "March",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "May",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "November",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "October",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "September",
                table: "MidSeasons");

            migrationBuilder.DropColumn(
                name: "April",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "August",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "December",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "February",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "January",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "July",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "June",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "March",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "May",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "November",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "October",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "September",
                table: "LowSeasons");

            migrationBuilder.DropColumn(
                name: "April",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "August",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "December",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "February",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "January",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "July",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "June",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "March",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "May",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "November",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "October",
                table: "HighSeasons");

            migrationBuilder.DropColumn(
                name: "September",
                table: "HighSeasons");

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HighSeasonId = table.Column<int>(type: "int", nullable: true),
                    Monthnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Months_HighSeasons_HighSeasonId",
                        column: x => x.HighSeasonId,
                        principalTable: "HighSeasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Months_HighSeasonId",
                table: "Months",
                column: "HighSeasonId");
        }
    }
}
