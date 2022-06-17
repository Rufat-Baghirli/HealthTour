using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_management.Migrations
{
    public partial class xzip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Children",
                table: "Children");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adults",
                table: "Adults");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "AdultId",
                table: "Adults");

            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Adults",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Children",
                table: "Children",
                column: "NewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adults",
                table: "Adults",
                column: "NewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Children",
                table: "Children");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adults",
                table: "Adults");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Adults");

            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "Children",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdultId",
                table: "Adults",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Children",
                table: "Children",
                column: "ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adults",
                table: "Adults",
                column: "AdultId");
        }
    }
}
