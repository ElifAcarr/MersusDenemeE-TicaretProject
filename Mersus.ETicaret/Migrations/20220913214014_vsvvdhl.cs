using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mersus.ETicaret.Migrations
{
    public partial class vsvvdhl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Boxs_ProductId",
                table: "Boxs",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boxs_Products_ProductId",
                table: "Boxs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boxs_Products_ProductId",
                table: "Boxs");

            migrationBuilder.DropIndex(
                name: "IX_Boxs_ProductId",
                table: "Boxs");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");
        }
    }
}
