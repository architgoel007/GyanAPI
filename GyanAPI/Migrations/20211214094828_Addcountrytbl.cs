using Microsoft.EntityFrameworkCore.Migrations;

namespace GyanAPI.Migrations
{
    public partial class Addcountrytbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryNameCid",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Cid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CountryNameCid",
                table: "Students",
                column: "CountryNameCid");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Country_CountryNameCid",
                table: "Students",
                column: "CountryNameCid",
                principalTable: "Country",
                principalColumn: "Cid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Country_CountryNameCid",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Students_CountryNameCid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CountryNameCid",
                table: "Students");
        }
    }
}
