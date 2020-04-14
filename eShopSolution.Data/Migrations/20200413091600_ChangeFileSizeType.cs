using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeFileSizeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("951a3a05-803f-4079-b9bb-6c7c5a7e1f92"),
                column: "ConcurrencyStamp",
                value: "bde8c63d-2d1f-4c76-8f48-cd85c3f63f6f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5eaff56-b5c5-48e3-9d0f-214970616b74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b677a7e2-07b6-4456-8098-1a70b2379bb7", "AQAAAAEAACcQAAAAEEnmImW89DG3bZ/SRPYyIeE78rpx6++BUKU6ROtmi7/kF+JiB/T5DTZv7OrQ3EzVwQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 13, 16, 15, 59, 566, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 4, 13, 16, 15, 59, 568, DateTimeKind.Local).AddTicks(3262));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("951a3a05-803f-4079-b9bb-6c7c5a7e1f92"),
                column: "ConcurrencyStamp",
                value: "7c7edcc2-5c42-4415-bfc1-1aeb1e611263");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5eaff56-b5c5-48e3-9d0f-214970616b74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ec024e26-e93d-4994-b7e5-e138553d6931", "AQAAAAEAACcQAAAAEG5HNUx6+vXDT+kyjRizvwUjqcW+DHYIM/dologSBRZeDroBWhII7JieYJgR0F1/dw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 13, 11, 41, 33, 367, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 4, 13, 11, 41, 33, 369, DateTimeKind.Local).AddTicks(3663));
        }
    }
}
