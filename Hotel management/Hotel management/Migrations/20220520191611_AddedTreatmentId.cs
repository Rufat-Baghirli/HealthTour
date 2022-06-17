using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class AddedTreatmentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Treatments_TreatmentId",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Treatments_TreatmentId",
                table: "Children");

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentId",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentId",
                table: "Adults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Treatments_TreatmentId",
                table: "Adults",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Treatments_TreatmentId",
                table: "Children",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Treatments_TreatmentId",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Treatments_TreatmentId",
                table: "Children");

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentId",
                table: "Children",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentId",
                table: "Adults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
