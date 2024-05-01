using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyShopInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedEvenMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreateDate", "ParentId" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6668), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreateDate", "ParentId" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6674), null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreateDate", "Description", "DiscountPercentage", "GeneralImage", "IsDelete", "Name", "Price" },
                values: new object[,]
                {
                    { -4, -4, new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7704), "", 10, null, false, "Product4", 1000 },
                    { -3, -3, new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7716), "", 10, null, false, "Product3", 1000 },
                    { -2, -4, new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7719), "", 10, null, false, "Product2", 2000 },
                    { -1, -3, new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7722), "", 10, null, false, "Product1", 2000 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "UserSelectedRoles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6746));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 1, 18, 39, 5, 585, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 1, 18, 39, 5, 585, DateTimeKind.Local).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreateDate", "ParentId" },
                values: new object[] { new DateTime(2024, 5, 1, 18, 39, 5, 585, DateTimeKind.Local).AddTicks(127), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreateDate", "ParentId" },
                values: new object[] { new DateTime(2024, 5, 1, 18, 39, 5, 585, DateTimeKind.Local).AddTicks(134), 0 });

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
    }
}
