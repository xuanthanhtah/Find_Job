using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "62ece127-7c24-4be0-b5fa-18a0bf42fa82");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c159bab3-4213-4be2-ab05-f8c36f24a27d", "AQAAAAEAACcQAAAAENLPqylAWr36em75g3ri9XchCuo4lWXR/pp0zEXVJs9KxjeUG12MNg+PoEGWMjugQg==" });
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
