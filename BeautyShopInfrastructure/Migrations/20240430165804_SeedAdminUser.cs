using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyShopInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "IsDelete", "MobileNumber", "Password", "Username" },
                values: new object[] { -1, new DateTime(2024, 4, 30, 21, 28, 3, 906, DateTimeKind.Local).AddTicks(6322), false, "09141001010", "20-08-20-E3-22-78-15-ED-17-56-A6-B5-31-E7-E0-D2", "Admin" });

            migrationBuilder.InsertData(
                table: "UserSelectedRoles",
                columns: new[] { "Id", "CreateDate", "IsDelete", "RoleId", "UserId" },
                values: new object[] { -1, new DateTime(2024, 4, 30, 21, 28, 3, 906, DateTimeKind.Local).AddTicks(6295), false, -1, -1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserSelectedRoles",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreateDate",
                value: new DateTime(2024, 4, 30, 20, 27, 25, 615, DateTimeKind.Local).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 30, 20, 27, 25, 615, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 30, 20, 27, 25, 614, DateTimeKind.Local).AddTicks(9929));
        }
    }
}
