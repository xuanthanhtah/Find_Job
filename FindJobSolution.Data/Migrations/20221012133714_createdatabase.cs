using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekers",
                columns: table => new
                {
                    JobSeekerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    National = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesiredSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekers", x => x.JobSeekerId);
                    table.ForeignKey(
                        name: "FK_JobSeekers_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeekers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recruiters",
                columns: table => new
                {
                    RecruiterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyIntroduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiters", x => x.RecruiterId);
                    table.ForeignKey(
                        name: "FK_Recruiters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerOldCompanys",
                columns: table => new
                {
                    JobSeekerOldCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobSeekerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerOldCompanys", x => x.JobSeekerOldCompanyId);
                    table.ForeignKey(
                        name: "FK_JobSeekerOldCompanys_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerSkills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    JobSeekerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerSkills", x => new { x.SkillId, x.JobSeekerId });
                    table.ForeignKey(
                        name: "FK_JobSeekerSkills_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeekerSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobInformations",
                columns: table => new
                {
                    JobInformationId = table.Column<int>(type: "int", nullable: false),
                    JobSeekerID = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    MaxSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    JobInformationTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 872, DateTimeKind.Local).AddTicks(7153)),
                    JobInformationTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 872, DateTimeKind.Local).AddTicks(7319)),
                    RecruiterId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInformations", x => x.JobInformationId);
                    table.ForeignKey(
                        name: "FK_JobInformations_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobInformations_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "Recruiters",
                        principalColumn: "RecruiterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecruiterGalleries",
                columns: table => new
                {
                    RecruiterGalleriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecruiterId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ApplyJobs",
                columns: table => new
                {
                    ApplyJobsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobSeekerID = table.Column<int>(type: "int", nullable: false),
                    JobInformationId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyJobs", x => x.ApplyJobsId);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_JobInformations_JobInformationId",
                        column: x => x.JobInformationId,
                        principalTable: "JobInformations",
                        principalColumn: "JobInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaveJobs",
                columns: table => new
                {
                    SaveJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveJobs", x => x.SaveJobId);
                    table.ForeignKey(
                        name: "FK_SaveJobs_JobInformations_JobInformationId",
                        column: x => x.JobInformationId,
                        principalTable: "JobInformations",
                        principalColumn: "JobInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerInApplyJobs",
                columns: table => new
                {
                    JobSeekerId = table.Column<int>(type: "int", nullable: false),
                    ApplyJobsId = table.Column<int>(type: "int", nullable: false),
                    ApplyJobsTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 874, DateTimeKind.Local).AddTicks(1197))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerInApplyJobs", x => new { x.ApplyJobsId, x.JobSeekerId });
                    table.ForeignKey(
                        name: "FK_JobSeekerInApplyJobs_ApplyJobs_ApplyJobsId",
                        column: x => x.ApplyJobsId,
                        principalTable: "ApplyJobs",
                        principalColumn: "ApplyJobsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSeekerInApplyJobs_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerInSaveJobs",
                columns: table => new
                {
                    JobSeekerId = table.Column<int>(type: "int", nullable: false),
                    SaveJobId = table.Column<int>(type: "int", nullable: false),
                    TimeSaveJob = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 12, 20, 37, 13, 874, DateTimeKind.Local).AddTicks(4164))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerInSaveJobs", x => new { x.JobSeekerId, x.SaveJobId });
                    table.ForeignKey(
                        name: "FK_JobSeekerInSaveJobs_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeekerInSaveJobs_SaveJobs_SaveJobId",
                        column: x => x.SaveJobId,
                        principalTable: "SaveJobs",
                        principalColumn: "SaveJobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "home", "this is home" },
                    { "keywork", "this is keywork" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "JobName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"), "7ee309ed-8162-4867-ad27-b3193217f1b5", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"), new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"), 0, "fb18415c-701c-4acc-be50-4ef5a8a0be74", new DateTime(2000, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "thanh26092000@gmail.com", true, "Thanh", "Xuan", false, null, "thanh26092000@gmail.com", "Lxthanh", "AQAAAAEAACcQAAAAECCc86r0XQgcRfMF1EsJ2bZ4AEt6slSiT0sYVVOvqdg0M0uxGXmeKSTVhx1m+Xma6g==", null, false, "", false, "Lxthanh" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_JobInformationId",
                table: "ApplyJobs",
                column: "JobInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_JobId",
                table: "JobInformations",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_RecruiterId",
                table: "JobInformations",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerInApplyJobs_JobSeekerId",
                table: "JobSeekerInApplyJobs",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerInSaveJobs_SaveJobId",
                table: "JobSeekerInSaveJobs",
                column: "SaveJobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerOldCompanys_JobSeekerId",
                table: "JobSeekerOldCompanys",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_JobId",
                table: "JobSeekers",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_UserId",
                table: "JobSeekers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerSkills_JobSeekerId",
                table: "JobSeekerSkills",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterGalleries_RecruiterId",
                table: "RecruiterGalleries",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruiters_UserId",
                table: "Recruiters",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaveJobs_JobInformationId",
                table: "SaveJobs",
                column: "JobInformationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.DropTable(
                name: "JobSeekerInApplyJobs");

            migrationBuilder.DropTable(
                name: "JobSeekerInSaveJobs");

            migrationBuilder.DropTable(
                name: "JobSeekerOldCompanys");

            migrationBuilder.DropTable(
                name: "JobSeekerSkills");

            migrationBuilder.DropTable(
                name: "RecruiterGalleries");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "ApplyJobs");

            migrationBuilder.DropTable(
                name: "SaveJobs");

            migrationBuilder.DropTable(
                name: "JobSeekers");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "JobInformations");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Recruiters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
