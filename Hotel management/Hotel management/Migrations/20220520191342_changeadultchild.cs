using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class changeadultchild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Children",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Adults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Children_TreatmentId",
                table: "Children",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Adults_TreatmentId",
                table: "Adults",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Treatments_TreatmentId",
                table: "Adults",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Treatments_TreatmentId",
                table: "Children",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Treatments_TreatmentId",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Treatments_TreatmentId",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_TreatmentId",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Adults_TreatmentId",
                table: "Adults");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Adults");
        }
    }
}
