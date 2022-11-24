using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class addchatidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "4a4a9375-c7b6-43e8-aa7f-9a549cb0e769");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("728d69ec-5ff4-4688-9107-d8906b264f79"),
                column: "ConcurrencyStamp",
                value: "c1385e93-e119-4b63-9c5a-93b5081684a3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f91c93e9-5527-4162-b7c5-dd3cba713a49"),
                column: "ConcurrencyStamp",
                value: "f67f18cf-a4a8-43da-8052-23d8b3be21fa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b1ec94f3-6866-4c56-a846-81f9429062c3", "AQAAAAEAACcQAAAAEFV/ZF707uTsv/V4Vpc/vNg1Xstp5drUoqe1YFHC/NKBUfRosCz/Ln1TZDX6c/psHA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "ba6fc8ed-53cd-4734-bf6e-513e8c7e38ad");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("728d69ec-5ff4-4688-9107-d8906b264f79"),
                column: "ConcurrencyStamp",
                value: "f2f98c4b-0a25-4a39-8eb9-de8318dad333");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f91c93e9-5527-4162-b7c5-dd3cba713a49"),
                column: "ConcurrencyStamp",
                value: "e8a7a400-995f-4f4c-9865-e91ad9a3ccad");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b85d273-a1e9-473e-9106-f9f826466238", "AQAAAAEAACcQAAAAENddOVV04snqhbuoHDntObKlFVrFozxvHe+78p4tHuVBLS3HsuuC51+Ah95JmkQHsQ==" });
        }
    }
}
