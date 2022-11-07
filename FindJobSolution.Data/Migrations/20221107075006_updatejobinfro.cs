using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updatejobinfro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "JobInformations");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "JobInformations");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "JobInformations");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "66493a44-c516-4d90-9841-0ca81660471b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fbfec6e2-fc9a-49ae-919a-f8aeddbf13b1", "AQAAAAEAACcQAAAAEAO9eG0+6rO564Rp156dHPZjLNZNS6jVr3sPlXxlPXRyrjzI590AY4DJhKwUhvtALw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Benefits",
                table: "JobInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "JobInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "JobInformations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "e61bfed4-7fe7-41b7-97db-ea6da9abbaac");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a12dd3c-305e-40a7-932e-cbb6820236bc", "AQAAAAEAACcQAAAAEE/5gvbRJ0RkZHGPdVNO3pvOaSWjGcM6FhzjvEKEdXCgFtHVOnxE9Xonw0EN6EVrlg==" });
        }
    }
}
