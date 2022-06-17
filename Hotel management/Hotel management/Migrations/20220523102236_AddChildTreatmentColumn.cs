using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class AddChildTreatmentColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Treatment_modelId",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Children_Treatment_modelId",
                table: "Children",
                column: "Treatment_modelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Treatments_Treatment_modelId",
                table: "Children",
                column: "Treatment_modelId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Treatments_Treatment_modelId",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_Treatment_modelId",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "Treatment_modelId",
                table: "Children");
        }
    }
}
