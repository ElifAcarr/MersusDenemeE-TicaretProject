using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mersus.ETicaret.Migrations
{
    public partial class vsvvdh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Boxs_BoxId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BoxId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BoxId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Boxs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Boxs");

            migrationBuilder.AddColumn<int>(
                name: "BoxId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BoxId",
                table: "Products",
                column: "BoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Boxs_BoxId",
                table: "Products",
                column: "BoxId",
                principalTable: "Boxs",
                principalColumn: "Id");
        }
    }
}
