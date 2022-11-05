using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updaterole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "42c75d9b-6a21-49d0-8e72-480f5f94ac21");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb64e5f5-bcdc-4468-b881-41d39be1b1f5", "AQAAAAEAACcQAAAAEEYiFztwhQ2OyvL0MKv9h8WdrksS5sRqglW9Y5AWTX8DdzvLxnS6mIJKZDDzEJ9Ivg==" });
        }
    }
}
