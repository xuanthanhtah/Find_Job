using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "745c632e-06be-4880-8d81-887f89a8c5db");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("728d69ec-5ff4-4688-9107-d8906b264f79"),
                column: "ConcurrencyStamp",
                value: "a407d56f-5032-4d2b-a4f4-9b571a0d4325");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f91c93e9-5527-4162-b7c5-dd3cba713a49"),
                column: "ConcurrencyStamp",
                value: "295e7c8f-4a00-4a3c-a70e-8da9c1f8970f");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a59a4f53-4f86-464a-8e11-bdb75184363a", "AQAAAAEAACcQAAAAECb/46YbJQDWfzQQnDM+DTo4EKLhP4q5aDLsNwdRLKlONNnva6f3ovMUAFteLikI2Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "d0a63e98-cd0c-438e-9d92-4ce7865f74f1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("728d69ec-5ff4-4688-9107-d8906b264f79"),
                column: "ConcurrencyStamp",
                value: "55305ac1-4249-45c1-8a97-4321b51b880d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f91c93e9-5527-4162-b7c5-dd3cba713a49"),
                column: "ConcurrencyStamp",
                value: "de414e80-ad3a-45d0-8e32-081b43839269");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0399faaa-3e47-48a3-b3ba-beec46fb0d72", "AQAAAAEAACcQAAAAEM5cqoK3UZojB+prGkduLocwp3HQ2KCsClZEmsLOFYWlKsefOwUVXUd+RETzf+4f7w==" });
        }
    }
}
