using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyShopInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSeenToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(6935));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "UserSelectedRoles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 5, 18, 57, 37, 459, DateTimeKind.Local).AddTicks(7087));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "Orders");

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
    }
}
