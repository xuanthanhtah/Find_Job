using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updaterecuiterimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecruiterGalleries");

            migrationBuilder.CreateTable(
                name: "RecruiterImages",
                columns: table => new
                {
                    RecruiterGalleriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecruiterId = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruiterImages", x => x.RecruiterGalleriesId);
                    table.ForeignKey(
                        name: "FK_RecruiterImages_Recruiters_RecruiterId",
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
                value: "a719d11a-3bfe-4e73-a941-8e48c7fd2846");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "864c1f81-61f6-439a-9f43-e1c982bca376", "AQAAAAEAACcQAAAAEMhH83ZKfzwq3AXZZnimDXl8Bn0F0faXBY5UoOLPomy4E9zkTtiovBOWyV4+u5mc2A==" });

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterImages_RecruiterId",
                table: "RecruiterImages",
                column: "RecruiterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecruiterImages");

            migrationBuilder.CreateTable(
                name: "RecruiterGalleries",
                columns: table => new
                {
                    RecruiterGalleriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecruiterId = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruiterGalleries", x => x.RecruiterGalleriesId);
                    table.ForeignKey(
                        name: "FK_RecruiterGalleries_Recruiters_RecruiterId",
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
                value: "28034781-6049-4653-ba49-fea12fc12278");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6bc88291-52d1-43a1-a28d-ddfed7d78eaa", "AQAAAAEAACcQAAAAEPoOZMCx9PLaxb53L2Xk9pjBd+ZwCw8dtL5hXQJDqMo3S+hrdyEldDZ8g72YaitabA==" });

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterGalleries_RecruiterId",
                table: "RecruiterGalleries",
                column: "RecruiterId");
        }
    }
}
