using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "2ff4d0f0-4b6b-4421-81ef-0afaa5712505");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "02abdcdc-4aa2-4b9a-8660-44ec164dc67a", "AQAAAAEAACcQAAAAELr3UzdiFGakRGajEkMd2U6bb14Jt62vA/uZVc6gCNiu/8V1TnvifiwOItxcOcwr3Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "aabcd09e-9d88-4ebd-8d79-692dab492c27");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98b0ce3a-0000-4c01-91db-4b5b8e6657be", "AQAAAAEAACcQAAAAEACbx8USC7X4qiWLrZaW0HRAN0o8QS1FvlhsUyJy9GBCRDGi5M+KcbZr7Mt/sS3F0Q==" });
        }
    }
}
