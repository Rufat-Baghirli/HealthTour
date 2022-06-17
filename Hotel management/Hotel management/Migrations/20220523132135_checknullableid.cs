using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class checknullableid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Treatments_Treatment_modelId",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Treatments_Treatment_modelId",
                table: "Children");

            migrationBuilder.AlterColumn<int>(
                name: "Treatment_modelId",
                table: "Children",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Treatment_modelId",
                table: "Adults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Treatments_Treatment_modelId",
                table: "Adults",
                column: "Treatment_modelId",
                principalTable: "Treatments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Treatments_Treatment_modelId",
                table: "Children",
                column: "Treatment_modelId",
                principalTable: "Treatments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Treatments_Treatment_modelId",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Treatments_Treatment_modelId",
                table: "Children");

            migrationBuilder.AlterColumn<int>(
                name: "Treatment_modelId",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Treatment_modelId",
                table: "Adults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Treatments_Treatment_modelId",
                table: "Adults",
                column: "Treatment_modelId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Treatments_Treatment_modelId",
                table: "Children",
                column: "Treatment_modelId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
