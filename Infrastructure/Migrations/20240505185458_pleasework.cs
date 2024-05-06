using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class pleasework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldType: "double precision");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 21, 54, 57, 356, DateTimeKind.Local).AddTicks(2222),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 5, 21, 48, 59, 278, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "itemOrders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "products",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "orders",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 21, 48, 59, 278, DateTimeKind.Local).AddTicks(8514),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 5, 21, 54, 57, 356, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "itemOrders",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
