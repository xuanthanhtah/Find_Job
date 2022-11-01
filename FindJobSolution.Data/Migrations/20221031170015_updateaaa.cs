using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updateaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avatars_Recruiters_RecruiterId",
                table: "Avatars");

            migrationBuilder.DropIndex(
                name: "IX_Avatars_RecruiterId",
                table: "Avatars");

            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "Avatars");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "6922b1f3-5f8a-4e3b-88fd-6139c159dc11");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb7c2dcf-8f08-451f-a0b4-3d00f05bffc1", "AQAAAAEAACcQAAAAEJmVCaKj7RLoA5GETu3dfC+Efq8Ec9n934f/djLyMhZd8HO3a5ZDV6+jKPnsLwkG+w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecruiterId",
                table: "Avatars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "ec81ec6f-bfee-4eab-b087-36e3cd824585");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10e03a5f-de5a-41ec-ae49-8f5d03b2866a", "AQAAAAEAACcQAAAAEEngXeT2EW/9j81DhsgFvmO/aT60Vaml5/1GkYHms8NgYKTbUq84R4eVj2/Cd6i4fA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Avatars_RecruiterId",
                table: "Avatars",
                column: "RecruiterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Avatars_Recruiters_RecruiterId",
                table: "Avatars",
                column: "RecruiterId",
                principalTable: "Recruiters",
                principalColumn: "RecruiterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
