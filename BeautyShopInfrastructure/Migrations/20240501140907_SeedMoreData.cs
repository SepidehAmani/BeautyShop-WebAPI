using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyShopInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 1, 18, 39, 5, 585, DateTimeKind.Local).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 1, 18, 39, 5, 585, DateTimeKind.Local).AddTicks(134));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "IsDelete", "Name", "ParentId" },
                values: new object[,]
                {
                    { -4, new DateTime(2024, 5, 1, 18, 39, 5, 585, DateTimeKind.Local).AddTicks(137), false, "زیردسته بندی آرایشی", -2 },
                    { -3, new DateTime(2024, 5, 1, 18, 39, 5, 585, DateTimeKind.Local).AddTicks(139), false, "زیردسته بندی بهداشتی", -1 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 1, 18, 39, 5, 584, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "UserSelectedRoles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 1, 18, 39, 5, 585, DateTimeKind.Local).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 1, 18, 39, 5, 585, DateTimeKind.Local).AddTicks(200));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 30, 21, 28, 3, 906, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 30, 21, 28, 3, 906, DateTimeKind.Local).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 30, 21, 28, 3, 906, DateTimeKind.Local).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "UserSelectedRoles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 30, 21, 28, 3, 906, DateTimeKind.Local).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 30, 21, 28, 3, 906, DateTimeKind.Local).AddTicks(6322));
        }
    }
}
