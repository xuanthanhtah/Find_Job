using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class createdb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobInformations_ApplyJobs_JobInformationId",
                table: "JobInformations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeSaveJob",
                table: "JobSeekerInSaveJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 862, DateTimeKind.Local).AddTicks(4084),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 39, 44, 311, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyJobsTime",
                table: "JobSeekerInApplyJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 862, DateTimeKind.Local).AddTicks(1329),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 39, 44, 311, DateTimeKind.Local).AddTicks(4471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeStart",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 860, DateTimeKind.Local).AddTicks(3388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 39, 44, 309, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeEnd",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 860, DateTimeKind.Local).AddTicks(3549),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 39, 44, 309, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.AddColumn<int>(
                name: "ApplyJobsId",
                table: "JobInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_ApplyJobsId",
                table: "JobInformations",
                column: "ApplyJobsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobInformations_ApplyJobs_ApplyJobsId",
                table: "JobInformations",
                column: "ApplyJobsId",
                principalTable: "ApplyJobs",
                principalColumn: "ApplyJobsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobInformations_ApplyJobs_ApplyJobsId",
                table: "JobInformations");

            migrationBuilder.DropIndex(
                name: "IX_JobInformations_ApplyJobsId",
                table: "JobInformations");

            migrationBuilder.DropColumn(
                name: "ApplyJobsId",
                table: "JobInformations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeSaveJob",
                table: "JobSeekerInSaveJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 39, 44, 311, DateTimeKind.Local).AddTicks(8385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 862, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyJobsTime",
                table: "JobSeekerInApplyJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 39, 44, 311, DateTimeKind.Local).AddTicks(4471),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 862, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeStart",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 39, 44, 309, DateTimeKind.Local).AddTicks(2187),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 860, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeEnd",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 39, 44, 309, DateTimeKind.Local).AddTicks(2423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 860, DateTimeKind.Local).AddTicks(3549));

            migrationBuilder.AddForeignKey(
                name: "FK_JobInformations_ApplyJobs_JobInformationId",
                table: "JobInformations",
                column: "JobInformationId",
                principalTable: "ApplyJobs",
                principalColumn: "ApplyJobsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
