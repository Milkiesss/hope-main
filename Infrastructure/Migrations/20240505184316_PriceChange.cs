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
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 21, 43, 15, 376, DateTimeKind.Local).AddTicks(7990),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 5, 21, 41, 20, 545, DateTimeKind.Local).AddTicks(9653));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 21, 41, 20, 545, DateTimeKind.Local).AddTicks(9653),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 5, 21, 43, 15, 376, DateTimeKind.Local).AddTicks(7990));
        }
    }
}
