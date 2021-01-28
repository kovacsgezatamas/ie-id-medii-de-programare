using Microsoft.EntityFrameworkCore.Migrations;

namespace kovacs_geza_tamas_project.Migrations
{
    public partial class CarMake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Make",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_MakeId",
                table: "Car",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Make_MakeId",
                table: "Car",
                column: "MakeId",
                principalTable: "Make",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Make_MakeId",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Make");

            migrationBuilder.DropIndex(
                name: "IX_Car_MakeId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Car");
        }
    }
}
