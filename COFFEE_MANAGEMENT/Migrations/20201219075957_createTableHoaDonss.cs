using Microsoft.EntityFrameworkCore.Migrations;

namespace COFFEE_MANAGEMENT_API.Migrations
{
    public partial class createTableHoaDonss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_BanId",
                table: "HoaDons",
                column: "BanId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_Bans_BanId",
                table: "HoaDons",
                column: "BanId",
                principalTable: "Bans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_Bans_BanId",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_BanId",
                table: "HoaDons");
        }
    }
}
