using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class tableavavtar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avatar",
                columns: table => new
                {
                    AvatarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Timespan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobSeekerId = table.Column<int>(type: "int", nullable: false),
                    RecruiterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatar", x => x.AvatarId);
                    table.ForeignKey(
                        name: "FK_Avatar_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avatar_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "Recruiters",
                        principalColumn: "RecruiterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "e2a2c326-2b41-4ad1-8509-ca55a1659747");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bbc22a44-1133-48e8-b5a4-c9aa30bbe427", "AQAAAAEAACcQAAAAEJlAQuXRL+oEM9BqehqVoVWuAZO+He4rbsAG7KHgLJwkupa4MIRlgljkxw7gKep6bA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Avatar_JobSeekerId",
                table: "Avatar",
                column: "JobSeekerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Avatar_RecruiterId",
                table: "Avatar",
                column: "RecruiterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avatar");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "507959a0-0b4d-4c4d-9539-d17663b68863");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44dad775-7607-45eb-8431-68c7eb66e923", "AQAAAAEAACcQAAAAEMSEkSopThXuy2IVT0vh1XivPv9yWW37c6Vbw4+e1zZOWN+8J5udTXPLS2ttcdYvxA==" });
        }
    }
}
