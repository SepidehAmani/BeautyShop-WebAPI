using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyShopInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "IsDelete", "Name", "ParentId" },
                values: new object[,]
                {
                    { -2, new DateTime(2024, 4, 30, 20, 27, 25, 615, DateTimeKind.Local).AddTicks(131), false, "آرایشی", 0 },
                    { -1, new DateTime(2024, 4, 30, 20, 27, 25, 615, DateTimeKind.Local).AddTicks(136), false, "بهداشتی", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "IsDelete", "UniqueName" },
                values: new object[] { -1, new DateTime(2024, 4, 30, 20, 27, 25, 614, DateTimeKind.Local).AddTicks(9929), false, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
