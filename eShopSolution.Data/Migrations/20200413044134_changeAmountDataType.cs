using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class changeAmountDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
