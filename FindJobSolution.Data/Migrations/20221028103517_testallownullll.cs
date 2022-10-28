using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class testallownullll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DesiredSalary",
                table: "JobSeekers",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .OldAnnotation("SqlServer:Sparse", false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DesiredSalary",
                table: "JobSeekers",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("SqlServer:Sparse", false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "7e3e3c1a-2578-4c66-981c-ac802026dea0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "838c47ae-1d9d-4d4c-8364-e9a5d47a59fa", "AQAAAAEAACcQAAAAEG3xOg54y7JHSQQprKtKHthsf4TfCgaCsa4uctqphnuehLvC1XU23vMav1MXSiYc0Q==" });
        }
    }
}
