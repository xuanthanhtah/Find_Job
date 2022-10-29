using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class editskill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificate",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "Skills",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SchoolName",
                table: "Skills",
                newName: "Experience");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "df47d76f-b6a1-45da-86e3-bbeae5003895");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "62c6602d-ccf4-4a5a-a930-4cf176fb57f0", "AQAAAAEAACcQAAAAEJ4v+1ZUQgIYDZfzqONdXMSpFfPS2OeNTaeDUo6adL2LY9H2nLnOsMHLSfmZ2Npqug==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Skills",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Skills",
                newName: "SchoolName");

            migrationBuilder.AddColumn<string>(
                name: "Certificate",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "dc1badc3-ef62-4516-8ced-c65bc552e323");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "daa86ae1-75a9-4318-995d-9524c21ec56a", "AQAAAAEAACcQAAAAEBuyV8HEu5DOgArRmEtAbUFNjs5bCGcb/gC2W+t7JqCttAUaUg0NYN+bTI4curydiw==" });
        }
    }
}
