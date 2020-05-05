using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingAPI.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item",
                table: "CurbsideOrders");

            migrationBuilder.AddColumn<string>(
                name: "Items",
                table: "CurbsideOrders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CurbsideOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Items",
                table: "CurbsideOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CurbsideOrders");

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "CurbsideOrders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
