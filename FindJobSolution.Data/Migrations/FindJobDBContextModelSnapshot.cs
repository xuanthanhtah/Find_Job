﻿// <auto-generated />
using System;
using FindJobSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FindJobSolution.Data.Migrations
{
    [DbContext(typeof(FindJobDBContext))]
    partial class FindJobDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FindJobSolution.Data.Entities.AppConfig", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.ToTable("AppConfigs", (string)null);

                    b.HasData(
                        new
                        {
                            Key = "home",
                            Value = "this is home"
                        },
                        new
                        {
                            Key = "keywork",
                            Value = "this is keywork"
                        });
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.ApplyJob", b =>
                {
                    b.Property<int>("ApplyJobsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplyJobsId"), 1L, 1);

                    b.Property<int>("JobInformationId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("ApplyJobsId");

                    b.HasIndex("JobInformationId")
                        .IsUnique();

                    b.ToTable("ApplyJobs");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.Cv", b =>
                {
                    b.Property<int>("CvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CvId"), 1L, 1);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timespan")
                        .HasColumnType("datetime2");

                    b.HasKey("CvId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("CVs", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"), 1L, 1);

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.ToTable("Jobs", (string)null);

                    b.HasData(
                        new
                        {
                            JobId = 1,
                            JobName = "IT"
                        },
                        new
                        {
                            JobId = 2,
                            JobName = "Marketing"
                        });
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobInformation", b =>
                {
                    b.Property<int>("JobInformationId")
                        .HasColumnType("int");

                    b.Property<string>("Benefits")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JobInformationTimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("JobInformationTimeStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobSeekerID")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MaxSalary")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("MinSalary")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("RecruiterId")
                        .HasColumnType("int");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("ViewCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("WorkingLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobInformationId");

                    b.HasIndex("JobId");

                    b.HasIndex("RecruiterId");

                    b.ToTable("JobInformations", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeeker", b =>
                {
                    b.Property<int>("JobSeekerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobSeekerId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DesiredSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Gender")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("National")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JobSeekerId");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("JobSeekers", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeekerInApplyJob", b =>
                {
                    b.Property<int>("ApplyJobsId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApplyJobsTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ApplyJobsId", "JobSeekerId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("JobSeekerInApplyJobs", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeekerInSaveJob", b =>
                {
                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<int>("SaveJobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeSaveJob")
                        .HasColumnType("datetime2");

                    b.HasKey("JobSeekerId", "SaveJobId");

                    b.HasIndex("SaveJobId");

                    b.ToTable("JobSeekerInSaveJobs", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeekerOldCompany", b =>
                {
                    b.Property<int>("JobSeekerOldCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobSeekerOldCompanyId"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkExperience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobSeekerOldCompanyId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("JobSeekerOldCompanys", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeekerSkill", b =>
                {
                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.HasKey("SkillId", "JobSeekerId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("JobSeekerSkills", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.Recruiter", b =>
                {
                    b.Property<int>("RecruiterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecruiterId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyIntroduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecruiterId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Recruiters", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.RecruiterGalleries", b =>
                {
                    b.Property<int>("RecruiterGalleriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecruiterGalleriesId"), 1L, 1);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.Property<int>("RecruiterId")
                        .HasColumnType("int");

                    b.Property<string>("src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecruiterGalleriesId");

                    b.HasIndex("RecruiterId");

                    b.ToTable("RecruiterGalleries", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                            ConcurrencyStamp = "dc1badc3-ef62-4516-8ced-c65bc552e323",

                            Name = "admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.SaveJob", b =>
                {
                    b.Property<int>("SaveJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaveJobId"), 1L, 1);

                    b.Property<int>("JobInformationId")
                        .HasColumnType("int");

                    b.HasKey("SaveJobId");

                    b.HasIndex("JobInformationId")
                        .IsUnique();

                    b.ToTable("SaveJobs", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"), 1L, 1);

                    b.Property<string>("Certificate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.ToTable("Skills", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "daa86ae1-75a9-4318-995d-9524c21ec56a",
                            Dob = new DateTime(2000, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "thanh26092000@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Thanh",
                            LastName = "Xuan",
                            LockoutEnabled = false,
                            NormalizedEmail = "thanh26092000@gmail.com",
                            NormalizedUserName = "Lxthanh",
                            PasswordHash = "AQAAAAEAACcQAAAAEBuyV8HEu5DOgArRmEtAbUFNjs5bCGcb/gC2W+t7JqCttAUaUg0NYN+bTI4curydiw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Lxthanh"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("70e7a246-e168-45e9-b78c-6f66b23f4633"),
                            UserId = new Guid("d1a052be-b2e2-4dbf-8778-da82a7bbcb98")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.ApplyJob", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.JobInformation", "JobInformation")
                        .WithOne("ApplyJob")
                        .HasForeignKey("FindJobSolution.Data.Entities.ApplyJob", "JobInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobInformation");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.Cv", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.JobSeeker", "JobSeeker")
                        .WithMany("Cvs")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobInformation", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.Job", "Job")
                        .WithMany("JobInformation")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FindJobSolution.Data.Entities.Recruiter", "Recruiter")
                        .WithMany("JobInformation")
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Recruiter");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeeker", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.Job", "Job")
                        .WithMany("JobSeekers")
                        .HasForeignKey("JobId");

                    b.HasOne("FindJobSolution.Data.Entities.User", "Users")
                        .WithOne("JobSeeker")
                        .HasForeignKey("FindJobSolution.Data.Entities.JobSeeker", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeekerInApplyJob", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.ApplyJob", "ApplyJob")
                        .WithMany("jobSeekerInApplyJobs")
                        .HasForeignKey("ApplyJobsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FindJobSolution.Data.Entities.JobSeeker", "JobSeeker")
                        .WithMany("jobSeekerInApplyJobs")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplyJob");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeekerInSaveJob", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.JobSeeker", "JobSeeker")
                        .WithMany("JobSeekerInSaveJobs")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FindJobSolution.Data.Entities.SaveJob", "SaveJob")
                        .WithMany("JobSeekerInSaveJobs")
                        .HasForeignKey("SaveJobId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobSeeker");

                    b.Navigation("SaveJob");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeekerOldCompany", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.JobSeeker", "JobSeeker")
                        .WithMany("JobSeekerOldCompanies")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeekerSkill", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.JobSeeker", "JobSeeker")
                        .WithMany("JobSeekerSkills")
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FindJobSolution.Data.Entities.Skill", "Skill")
                        .WithMany("JobSeekerSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobSeeker");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.Recruiter", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.User", "Users")
                        .WithOne("Recruiter")
                        .HasForeignKey("FindJobSolution.Data.Entities.Recruiter", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.RecruiterGalleries", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.Recruiter", "Recruiter")
                        .WithMany("recruiterGalleries")
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recruiter");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.SaveJob", b =>
                {
                    b.HasOne("FindJobSolution.Data.Entities.JobInformation", "JobInformation")
                        .WithOne("SaveJob")
                        .HasForeignKey("FindJobSolution.Data.Entities.SaveJob", "JobInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobInformation");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.ApplyJob", b =>
                {
                    b.Navigation("jobSeekerInApplyJobs");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.Job", b =>
                {
                    b.Navigation("JobInformation");

                    b.Navigation("JobSeekers");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobInformation", b =>
                {
                    b.Navigation("ApplyJob")
                        .IsRequired();

                    b.Navigation("SaveJob")
                        .IsRequired();
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.JobSeeker", b =>
                {
                    b.Navigation("Cvs");

                    b.Navigation("JobSeekerInSaveJobs");

                    b.Navigation("JobSeekerOldCompanies");

                    b.Navigation("JobSeekerSkills");

                    b.Navigation("jobSeekerInApplyJobs");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.Recruiter", b =>
                {
                    b.Navigation("JobInformation");

                    b.Navigation("recruiterGalleries");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.SaveJob", b =>
                {
                    b.Navigation("JobSeekerInSaveJobs");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.Skill", b =>
                {
                    b.Navigation("JobSeekerSkills");
                });

            modelBuilder.Entity("FindJobSolution.Data.Entities.User", b =>
                {
                    b.Navigation("JobSeeker")
                        .IsRequired();

                    b.Navigation("Recruiter")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
