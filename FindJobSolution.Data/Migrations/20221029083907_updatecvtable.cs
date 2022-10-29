using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updatecvtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_Jobs_JobId",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "CVs");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "CVs",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4786681-d41a-4fff-9854-b97c3765e53d", "AQAAAAEAACcQAAAAEP7NVeE2FF0F9Crd4qmEdQPBIVG8C2dBscBLThzDxcmUwgkft0GFx2QW93v9LhvlRA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_Jobs_JobId",
                table: "JobSeekers",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_Jobs_JobId",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "CVs");

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "CVs",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_Jobs_JobId",
                table: "JobSeekers",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId");
        }
    }
}
