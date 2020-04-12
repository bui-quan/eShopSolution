using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("951a3a05-803f-4079-b9bb-6c7c5a7e1f92"), "1a5b4e97-04db-4e8f-bea0-57b22c9c5e7d", "Administrator for admin", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("a5eaff56-b5c5-48e3-9d0f-214970616b74"), new Guid("951a3a05-803f-4079-b9bb-6c7c5a7e1f92") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a5eaff56-b5c5-48e3-9d0f-214970616b74"), 0, "b9a5ab50-8234-4c14-bed4-98603d6b299d", new DateTime(1984, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "quanb6184@gmail.com", true, "Bui", "Quan", false, null, "quanb6184@gmail.com", "Admin", "AQAAAAEAACcQAAAAEG0Vs5rD4xsrKl0k1BVgyxQAW+uDaTy5aQCgK2muwDha0etVxhDmLNwoEr0JVABnAA==", null, false, "", false, "Admin" });

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
                value: new DateTime(2020, 4, 12, 9, 1, 38, 472, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 4, 12, 9, 1, 38, 474, DateTimeKind.Local).AddTicks(3067));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("951a3a05-803f-4079-b9bb-6c7c5a7e1f92"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("a5eaff56-b5c5-48e3-9d0f-214970616b74"), new Guid("951a3a05-803f-4079-b9bb-6c7c5a7e1f92") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5eaff56-b5c5-48e3-9d0f-214970616b74"));

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
                value: new DateTime(2020, 4, 12, 8, 35, 10, 137, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2020, 4, 12, 8, 35, 10, 139, DateTimeKind.Local).AddTicks(1493));
        }
    }
}
