using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class addadulttreaatmnet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Treatment_modelId",
                table: "Adults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adults_Treatment_modelId",
                table: "Adults",
                column: "Treatment_modelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Treatments_Treatment_modelId",
                table: "Adults",
                column: "Treatment_modelId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Treatments_Treatment_modelId",
                table: "Adults");

            migrationBuilder.DropIndex(
                name: "IX_Adults_Treatment_modelId",
                table: "Adults");

            migrationBuilder.DropColumn(
                name: "Treatment_modelId",
                table: "Adults");
        }
    }
}
