using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MashStudyDotNetCoreWebAPITutorials.Migrations
{
    public partial class AddLastUpdatedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastUpdatedby",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "LastUpdatedby",
                table: "Cities");
        }
    }
}
