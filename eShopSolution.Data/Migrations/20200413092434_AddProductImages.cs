using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddProductImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("951a3a05-803f-4079-b9bb-6c7c5a7e1f92"),
                column: "ConcurrencyStamp",
                value: "5415c435-d4f7-4ceb-8993-b510604b2653");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5eaff56-b5c5-48e3-9d0f-214970616b74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee9944a5-cc06-4535-9927-b49ca2be246b", "AQAAAAEAACcQAAAAEJayQk3abgD63k2FQcu2wTSWNAxB7YClJRedMYwHFbGCsZKWwVLrpkFSovspkEYOTQ==" });

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
                value: new DateTime(2020, 4, 13, 16, 24, 33, 354, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 4, 13, 16, 24, 33, 356, DateTimeKind.Local).AddTicks(3417));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
