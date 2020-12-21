using Microsoft.EntityFrameworkCore.Migrations;

namespace COFFEE_MANAGEMENT_API.Migrations
{
    public partial class changetypenameinproductcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductCategory",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Name",
                table: "ProductCategory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
