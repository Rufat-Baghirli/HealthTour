using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class reservationdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Reservations_ReservationId",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Reservations_ReservationId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_ReservationId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ReservationId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Children_ReservationId",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Adults_ReservationId",
                table: "Adults");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Adults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Children",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Adults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Checkin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Checkout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Night = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ReservationId",
                table: "Rooms",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_ReservationId",
                table: "Children",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Adults_ReservationId",
                table: "Adults",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Reservations_ReservationId",
                table: "Adults",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Reservations_ReservationId",
                table: "Children",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_ReservationId",
                table: "Rooms",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
