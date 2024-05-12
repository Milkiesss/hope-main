using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_itemOrders_OrderId_ProductId",
                table: "itemOrders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 13, 2, 27, 26, 744, DateTimeKind.Local).AddTicks(5042),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 13, 2, 12, 34, 816, DateTimeKind.Local).AddTicks(737));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 13, 2, 12, 34, 816, DateTimeKind.Local).AddTicks(737),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 13, 2, 27, 26, 744, DateTimeKind.Local).AddTicks(5042));

            migrationBuilder.CreateIndex(
                name: "IX_itemOrders_OrderId_ProductId",
                table: "itemOrders",
                columns: new[] { "OrderId", "ProductId" },
                unique: true);
        }
    }
}
