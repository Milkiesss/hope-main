using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 21, 7, 25, 805, DateTimeKind.Local).AddTicks(1962),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 6, 20, 46, 9, 608, DateTimeKind.Local).AddTicks(2062));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 20, 46, 9, 608, DateTimeKind.Local).AddTicks(2062),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 6, 21, 7, 25, 805, DateTimeKind.Local).AddTicks(1962));
        }
    }
}
