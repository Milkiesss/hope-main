using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PriceChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "products",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "orders",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 21, 34, 44, 389, DateTimeKind.Local).AddTicks(9600),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 4, 30, 22, 32, 3, 849, DateTimeKind.Local).AddTicks(4594));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "itemOrders",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 22, 32, 3, 849, DateTimeKind.Local).AddTicks(4594),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 5, 21, 34, 44, 389, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "itemOrders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
