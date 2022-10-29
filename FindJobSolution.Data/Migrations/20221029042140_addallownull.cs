using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class addallownull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(name: "JobId", table: "JobSeekers", nullable: true);
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_Jobs_JobId",
                table: "JobSeekers");

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_Jobs_JobId",
                table: "JobSeekers",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_Jobs_JobId",
                table: "JobSeekers");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "262837dc-6461-4219-9f5e-456166b3ecf1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ac1bbec-6cc2-4c52-b8b2-367b0361f201", "AQAAAAEAACcQAAAAEOVG/qPIWMcOhjlE4z5/aVrTDxQ8dEW4ADgMM20vpYYnri6Gj67NKauettT/+95Jgg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_Jobs_JobId",
                table: "JobSeekers",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
