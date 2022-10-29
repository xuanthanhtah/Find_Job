using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updatetableuserrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dob",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dob",
                table: "JobSeekers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "d6afbe08-bbd0-4c7d-8c1b-653e42a2d974");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash" },
                values: new object[] { "61baf82a-a4b7-4378-9e65-2230d65d3930", "Xuan Thanh", "AQAAAAEAACcQAAAAEJiDUBtfKvWjIF6mWHxxNIdVB0E9QV8lyaDDgZu9Y7yBcTW96ro1pX7hwjJ8+7xhMg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dob",
                table: "JobSeekers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dob",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "24a7fe36-0e6c-45f8-8fa3-2d484c553018");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "Dob", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "d4786681-d41a-4fff-9854-b97c3765e53d", new DateTime(2000, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thanh", "Xuan", "AQAAAAEAACcQAAAAEP7NVeE2FF0F9Crd4qmEdQPBIVG8C2dBscBLThzDxcmUwgkft0GFx2QW93v9LhvlRA==" });
        }
    }
}
