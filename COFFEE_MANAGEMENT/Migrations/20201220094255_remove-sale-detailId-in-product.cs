using Microsoft.EntityFrameworkCore.Migrations;

namespace COFFEE_MANAGEMENT_API.Migrations
{
    public partial class removesaledetailIdinproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailss_Products_ProductId",
                table: "SalesDetailss");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetailss_ProductId",
                table: "SalesDetailss");

            migrationBuilder.DropColumn(
                name: "SalesDetailsId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SalesDetailsId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailss_ProductId",
                table: "SalesDetailss",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailss_Products_ProductId",
                table: "SalesDetailss",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
