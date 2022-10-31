using FindJobSolution.Data.Configurations;
using FindJobSolution.Data.Entities;
using FindJobSolution.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.EF
{
    public class FindJobDBContext : IdentityDbContext<User, Role, Guid>
    {
        public FindJobDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure using fluent API
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ApplyJobConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new JobInfomationConfiguration());
            modelBuilder.ApplyConfiguration(new JobSeeekerConfiguration());
            modelBuilder.ApplyConfiguration(new JobSeekerOldCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new RecruiterConfiguration());
            modelBuilder.ApplyConfiguration(new RecruiterImagesConfiguration());
            modelBuilder.ApplyConfiguration(new SaveJobConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new JobSeekerSkillConfiguration());
            modelBuilder.ApplyConfiguration(new CvConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.RoleId, x.UserId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            //sedding
            modelBuilder.Seed();

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<RecruiterImages> RecruiterImages { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<JobSeekerOldCompany> JobSeekerOldCompanies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobInformation> JobInformations { get; set; }
        public DbSet<ApplyJob> ApplyJobs { get; set; }
        public DbSet<SaveJob> SaveJobs { get; set; }
        public DbSet<JobSeekerSkill> JobSeekerSkills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cv> Cvs { get; set; }
    }
}