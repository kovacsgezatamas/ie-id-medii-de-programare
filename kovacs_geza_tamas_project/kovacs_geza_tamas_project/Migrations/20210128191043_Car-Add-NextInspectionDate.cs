using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kovacs_geza_tamas_project.Migrations
{
    public partial class CarAddNextInspectionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NextInspectionDate",
                table: "Car",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextInspectionDate",
                table: "Car");
        }
    }
}
