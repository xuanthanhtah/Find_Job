using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updatetablecv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "CVs",
                newName: "FilePath");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "28034781-6049-4653-ba49-fea12fc12278");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6bc88291-52d1-43a1-a28d-ddfed7d78eaa", "AQAAAAEAACcQAAAAEPoOZMCx9PLaxb53L2Xk9pjBd+ZwCw8dtL5hXQJDqMo3S+hrdyEldDZ8g72YaitabA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "CVs",
                newName: "ImagePath");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "2b69122d-b015-4408-8194-c2a46d1d2b49");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0eb071b8-6163-422e-a7af-11362af6748f", "AQAAAAEAACcQAAAAEIlH6uJinMsHlNxjdfHDbttrrxq3AnQ/ol1wfxtYvBQtPkzpEMx+aLBWb08M/pLZSg==" });
        }
    }
}
