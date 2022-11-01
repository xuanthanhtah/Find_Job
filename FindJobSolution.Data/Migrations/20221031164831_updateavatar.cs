using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class updateavatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avatar_JobSeekers_JobSeekerId",
                table: "Avatar");

            migrationBuilder.DropForeignKey(
                name: "FK_Avatar_Recruiters_RecruiterId",
                table: "Avatar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avatar",
                table: "Avatar");

            migrationBuilder.RenameTable(
                name: "Avatar",
                newName: "Avatars");

            migrationBuilder.RenameIndex(
                name: "IX_Avatar_RecruiterId",
                table: "Avatars",
                newName: "IX_Avatars_RecruiterId");

            migrationBuilder.RenameIndex(
                name: "IX_Avatar_JobSeekerId",
                table: "Avatars",
                newName: "IX_Avatars_JobSeekerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avatars",
                table: "Avatars",
                column: "AvatarId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Avatars_JobSeekers_JobSeekerId",
                table: "Avatars",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "JobSeekerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avatars_Recruiters_RecruiterId",
                table: "Avatars",
                column: "RecruiterId",
                principalTable: "Recruiters",
                principalColumn: "RecruiterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avatars_JobSeekers_JobSeekerId",
                table: "Avatars");

            migrationBuilder.DropForeignKey(
                name: "FK_Avatars_Recruiters_RecruiterId",
                table: "Avatars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avatars",
                table: "Avatars");

            migrationBuilder.RenameTable(
                name: "Avatars",
                newName: "Avatar");

            migrationBuilder.RenameIndex(
                name: "IX_Avatars_RecruiterId",
                table: "Avatar",
                newName: "IX_Avatar_RecruiterId");

            migrationBuilder.RenameIndex(
                name: "IX_Avatars_JobSeekerId",
                table: "Avatar",
                newName: "IX_Avatar_JobSeekerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avatar",
                table: "Avatar",
                column: "AvatarId");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                column: "ConcurrencyStamp",
                value: "9e2ee0d7-85e1-4b04-ad9b-31fcfd15fb3f");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7646a1f9-e772-42f9-8263-45d7654b5240", "AQAAAAEAACcQAAAAEEhqheb66uB8tU8UbjnZrDD3RImqTTgIxcpFOHIw7o8dn1Y+HhviJRwa6jDRAtBVxg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Avatar_JobSeekers_JobSeekerId",
                table: "Avatar",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "JobSeekerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avatar_Recruiters_RecruiterId",
                table: "Avatar",
                column: "RecruiterId",
                principalTable: "Recruiters",
                principalColumn: "RecruiterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
