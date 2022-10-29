using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updatecv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cv_JobSeekers_JobSeekerId",
                table: "Cv");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cv",
                table: "Cv");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Cv");

            migrationBuilder.RenameTable(
                name: "Cv",
                newName: "CVs");

            migrationBuilder.RenameColumn(
                name: "fileType",
                table: "CVs",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CVs",
                newName: "Caption");

            migrationBuilder.RenameIndex(
                name: "IX_Cv_JobSeekerId",
                table: "CVs",
                newName: "IX_CVs_JobSeekerId");

            migrationBuilder.AlterColumn<int>(
                name: "FileType",
                table: "CVs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "CVs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CVs",
                table: "CVs",
                column: "CvId");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "aa7077b7-8a36-48ce-a4eb-cb5da1c9087e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff312a10-c441-48d0-9cf6-595ab483c761", "AQAAAAEAACcQAAAAEGAHjLc5CNGdG0gtAz2QtFgXYwtJTgbSSW2rHI5x2ltTKCXc51QT/Kjh2QY7vtBU7A==" });

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_JobSeekers_JobSeekerId",
                table: "CVs",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "JobSeekerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_JobSeekers_JobSeekerId",
                table: "CVs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CVs",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "CVs");

            migrationBuilder.RenameTable(
                name: "CVs",
                newName: "Cv");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "Cv",
                newName: "fileType");

            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "Cv",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_CVs_JobSeekerId",
                table: "Cv",
                newName: "IX_Cv_JobSeekerId");

            migrationBuilder.AlterColumn<string>(
                name: "fileType",
                table: "Cv",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Cv",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cv",
                table: "Cv",
                column: "CvId");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "a79d872f-12be-403d-9e1d-c491430d419e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ce2dd0a-2ab7-4503-a4c6-fb6bc55dce23", "AQAAAAEAACcQAAAAED1wkLellwNV0WIQS1OxZZRFgauXocUgV3qfkjAoDjohMvOfQ+XUKxNlPw3b2N2V1A==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cv_JobSeekers_JobSeekerId",
                table: "Cv",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "JobSeekerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
