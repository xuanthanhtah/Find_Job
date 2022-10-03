using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class createdb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeSaveJob",
                table: "JobSeekerInSaveJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 1, 14, 18, 928, DateTimeKind.Local).AddTicks(7216),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 862, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyJobsTime",
                table: "JobSeekerInApplyJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 1, 14, 18, 928, DateTimeKind.Local).AddTicks(3611),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 862, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeStart",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 1, 14, 18, 926, DateTimeKind.Local).AddTicks(3821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 860, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeEnd",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 1, 14, 18, 926, DateTimeKind.Local).AddTicks(4039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 860, DateTimeKind.Local).AddTicks(3549));

            migrationBuilder.AlterColumn<int>(
                name: "JobInformationId",
                table: "JobInformations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeSaveJob",
                table: "JobSeekerInSaveJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 862, DateTimeKind.Local).AddTicks(4084),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 1, 14, 18, 928, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyJobsTime",
                table: "JobSeekerInApplyJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 862, DateTimeKind.Local).AddTicks(1329),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 1, 14, 18, 928, DateTimeKind.Local).AddTicks(3611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeStart",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 860, DateTimeKind.Local).AddTicks(3388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 1, 14, 18, 926, DateTimeKind.Local).AddTicks(3821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JobInformationTimeEnd",
                table: "JobInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 0, 53, 40, 860, DateTimeKind.Local).AddTicks(3549),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 1, 14, 18, 926, DateTimeKind.Local).AddTicks(4039));

            migrationBuilder.AlterColumn<int>(
                name: "JobInformationId",
                table: "JobInformations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
