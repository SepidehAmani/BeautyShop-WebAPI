using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyShopInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeAddressNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(5768));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "UserSelectedRoles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 4, 22, 41, 31, 4, DateTimeKind.Local).AddTicks(4766));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(1233));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(816));

            migrationBuilder.UpdateData(
                table: "UserSelectedRoles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(1316));
        }
    }
}
