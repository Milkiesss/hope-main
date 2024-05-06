using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "products",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "orders",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 21, 48, 59, 278, DateTimeKind.Local).AddTicks(8514),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 5, 21, 43, 15, 376, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "itemOrders",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "products",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "orders",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 21, 43, 15, 376, DateTimeKind.Local).AddTicks(7990),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 5, 21, 48, 59, 278, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "itemOrders",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
