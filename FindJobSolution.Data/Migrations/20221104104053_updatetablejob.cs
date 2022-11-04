using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updatetablejob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "6922b1f3-5f8a-4e3b-88fd-6139c159dc11");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb7c2dcf-8f08-451f-a0b4-3d00f05bffc1", "AQAAAAEAACcQAAAAEJmVCaKj7RLoA5GETu3dfC+Efq8Ec9n934f/djLyMhZd8HO3a5ZDV6+jKPnsLwkG+w==" });
        }
    }
}
