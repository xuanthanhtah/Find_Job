using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class addviewcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "JobInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Cv",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "a109a9e7-290d-4e3c-96f4-c2c426bf6e0c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aaaabee0-36f5-46df-b503-58b98843fb8d", "AQAAAAEAACcQAAAAED5FGJJxVG61+abbfKfmi34N2H7vGiN56fdgNuwgBeuSNCSVbYN5vNM4FouV+qY3Kg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "JobInformations");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Cv");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "f52da4d3-0eff-44fb-8f28-f3e8a69947c5");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "154b313a-46cc-4ad6-a054-7a00e0cc0714", "AQAAAAEAACcQAAAAEBnyv0NbaYmPi4VlBn59x2HbPB8UkVsAuSo5ljqmThK8r3riEfF+PN7/3xzEyxEHCw==" });
        }
    }
}
