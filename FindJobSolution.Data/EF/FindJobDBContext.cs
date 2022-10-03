using FindJobSolution.Data.Configurations;
using FindJobSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.EF
{
    public class FindJobDBContext : DbContext
    {
        public FindJobDBContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ApplyJobConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new JobInformationConfiguration());
            modelBuilder.ApplyConfiguration(new JobSeeekerConfiguration());
            modelBuilder.ApplyConfiguration(new JobSeekerOldCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new RecruiterConfiguration());
            modelBuilder.ApplyConfiguration(new RecruiterGalleriesConfiguration());
            modelBuilder.ApplyConfiguration(new SaveJobConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new JobSeekerInApplyJobConfiguration());
            modelBuilder.ApplyConfiguration(new JobSeekerInSaveJobConfiguration());
            modelBuilder.ApplyConfiguration(new JobSeekerSkillConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<RecruiterGalleries> RecruiterGalleries { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<JobSeekerOldCompany> JobSeekerOldCompanies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobInformation> JobInformations { get; set; }
        public DbSet<ApplyJob> ApplyJobs { get; set; }
        public DbSet<SaveJob> SaveJobs { get; set; }
        public DbSet<JobSeekerInApplyJob> JobSeekerInApplyJobs { get; set; }
        public DbSet<JobSeekerInSaveJob> JobSeekerInSaveJobs { get; set; }
        public DbSet<JobSeekerSkill> JobSeekerSkills { get; set; }
    }
}
