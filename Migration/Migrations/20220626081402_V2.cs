using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migration.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId_ProductId",
                table: "Order",
                columns: new[] { "CustomerId", "ProductId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId_ProductId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");
        }
    }
}
