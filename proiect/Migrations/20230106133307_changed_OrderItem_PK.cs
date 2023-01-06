using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect.Migrations
{
    /// <inheritdoc />
    public partial class changedOrderItemPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderId",
                table: "orderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems");

            migrationBuilder.DropIndex(
                name: "IX_orderItems_OrderId",
                table: "orderItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems",
                columns: new[] { "OrderId", "ItemId" });
        }
    }
}
