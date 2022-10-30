using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updatetablerecuiter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Recruiters",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "e508fe29-2110-4e19-8c70-38f406dbd63a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5650e1e1-a322-445f-b707-d94da5e60d34", "AQAAAAEAACcQAAAAEFmvdxHk+udEEHOyzFEMd+Cv6Ll0UvBFBAxA2fAGf9qrbqNPqw5tlzLyIGtYB9lqIg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Recruiters");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "6dc58c82-4fe8-4915-bd73-f55bd882f162");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a470c35a-c6eb-4e45-b6ab-44a3b43277e0", "AQAAAAEAACcQAAAAEM+QlsGbnrFvhgEhf5J4Nw4yXBCjUjgKuD6MpAaQSGU9GlmDuTcOgj+dERPAzqaDwQ==" });
        }
    }
}
