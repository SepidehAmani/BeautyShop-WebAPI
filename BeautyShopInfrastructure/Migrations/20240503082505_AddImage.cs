using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyShopInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneralImage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProductItems");

            migrationBuilder.AddColumn<int>(
                name: "GeneralImageId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "ProductItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

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
                columns: new[] { "CreateDate", "GeneralImageId" },
                values: new object[] { new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(2360), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreateDate", "GeneralImageId" },
                values: new object[] { new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(2371), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreateDate", "GeneralImageId" },
                values: new object[] { new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(2374), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreateDate", "GeneralImageId" },
                values: new object[] { new DateTime(2024, 5, 3, 12, 55, 4, 777, DateTimeKind.Local).AddTicks(2377), null });

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_GeneralImageId",
                table: "Products",
                column: "GeneralImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ImageId",
                table: "ProductItems",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Images_ImageId",
                table: "ProductItems",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_GeneralImageId",
                table: "Products",
                column: "GeneralImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Images_ImageId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_GeneralImageId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Products_GeneralImageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_ImageId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "GeneralImageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ProductItems");

            migrationBuilder.AddColumn<string>(
                name: "GeneralImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true);

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
                column: "CreateDate",
                value: new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "CreateDate", "GeneralImage" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7704), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreateDate", "GeneralImage" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7716), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreateDate", "GeneralImage" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7719), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreateDate", "GeneralImage" },
                values: new object[] { new DateTime(2024, 5, 2, 0, 19, 56, 470, DateTimeKind.Local).AddTicks(7722), null });

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
    }
}
