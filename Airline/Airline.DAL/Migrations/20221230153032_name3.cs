using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.DAL.Migrations
{
    public partial class name3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e668b11-5769-42a0-918c-729bf02c3234");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a7162227-fded-4564-9e28-4ad13cb0c012", 0, "29d46a9d-196e-4fbd-a259-aed8138ee1b1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "misa@gmail.com", false, "Michael", "TSyntar", false, null, null, null, null, null, false, "eab2dbbc-7a4d-477c-9511-266598e5a80c", false, "Misa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7162227-fded-4564-9e28-4ad13cb0c012");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4e668b11-5769-42a0-918c-729bf02c3234", 0, "6fb13fd5-8674-420f-a708-97b714910730", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "misa@gmail.com", false, "Michael", "TSyntar", false, null, null, null, null, null, false, "f0b23ca0-98b2-4c55-b5c1-ca5bdbd8e786", false, "Misa" });
        }
    }
}
