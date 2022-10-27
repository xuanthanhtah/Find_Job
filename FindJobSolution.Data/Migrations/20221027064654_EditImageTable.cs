using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class EditImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "RecruiterGalleries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RecruiterGalleries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FileSize",
                table: "RecruiterGalleries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeSaveJob",
                table: "JobSeekerInSaveJobs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 874, DateTimeKind.Local).AddTicks(4164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyJobsTime",
                table: "JobSeekerInApplyJobs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 874, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeStart",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 872, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeEnd",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 872, DateTimeKind.Local).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "19e88952-ee53-48aa-94d2-cde72fbc7c66");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20ae934e-c1b5-42b8-a553-4cbb671bb889", "AQAAAAEAACcQAAAAEM1EZdlHZFbJpN5MHZhGPrnmvM7JL/JbGxBgWkFZAxDbpC4FWoY9u0nMbf4l8gYpsQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caption",
                table: "RecruiterGalleries");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RecruiterGalleries");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "RecruiterGalleries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeSaveJob",
                table: "JobSeekerInSaveJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 874, DateTimeKind.Local).AddTicks(4164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyJobsTime",
                table: "JobSeekerInApplyJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 874, DateTimeKind.Local).AddTicks(1197),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeStart",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 872, DateTimeKind.Local).AddTicks(7153),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeEnd",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 872, DateTimeKind.Local).AddTicks(7319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "7ee309ed-8162-4867-ad27-b3193217f1b5");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb18415c-701c-4acc-be50-4ef5a8a0be74", "AQAAAAEAACcQAAAAECCc86r0XQgcRfMF1EsJ2bZ4AEt6slSiT0sYVVOvqdg0M0uxGXmeKSTVhx1m+Xma6g==" });
        }
    }
}
