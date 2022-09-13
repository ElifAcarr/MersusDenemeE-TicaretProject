using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mersus.ETicaret.Migrations
{
    public partial class Urunselleras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Boxs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Boxs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
