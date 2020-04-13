using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class changePriceDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("951a3a05-803f-4079-b9bb-6c7c5a7e1f92"),
                column: "ConcurrencyStamp",
                value: "f58b4073-129d-46d2-8618-0daee553b05c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5eaff56-b5c5-48e3-9d0f-214970616b74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "636cfee9-d6f0-4f75-8b75-3914920d587d", "AQAAAAEAACcQAAAAEHdA3LlwwR+8Tg5Sy7VrebMIJ0D0QKDbv6JaiH/yzpAhyvES5iSZOPwO0wKLRTom/g==" });

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
                value: new DateTime(2020, 4, 13, 11, 38, 0, 319, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 4, 13, 11, 38, 0, 321, DateTimeKind.Local).AddTicks(4108));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("951a3a05-803f-4079-b9bb-6c7c5a7e1f92"),
                column: "ConcurrencyStamp",
                value: "3c0e1e6d-0794-4080-8388-c4284cc95022");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5eaff56-b5c5-48e3-9d0f-214970616b74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "97769c87-c76e-4cd7-b92c-dffca339c9c9", "AQAAAAEAACcQAAAAEKLpbD9juZLuDZNYU2HL2GCqkdDp8Y0RUxjVY+sz9Jv5l7fCiu7Dx0mRlmst4s+F1A==" });

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
                value: new DateTime(2020, 4, 13, 9, 5, 23, 732, DateTimeKind.Local).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 4, 13, 9, 5, 23, 734, DateTimeKind.Local).AddTicks(3454));
        }
    }
}
