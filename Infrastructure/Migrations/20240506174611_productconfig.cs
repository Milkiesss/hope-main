using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class productconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 20, 46, 9, 608, DateTimeKind.Local).AddTicks(2062),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 5, 21, 56, 41, 363, DateTimeKind.Local).AddTicks(1735));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrder",
                table: "orders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 21, 56, 41, 363, DateTimeKind.Local).AddTicks(1735),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 5, 6, 20, 46, 9, 608, DateTimeKind.Local).AddTicks(2062));
        }
    }
}
