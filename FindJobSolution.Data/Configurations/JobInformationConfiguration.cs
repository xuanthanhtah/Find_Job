using FindJobSolution.Data.Entities;
using FindJobSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Configurations
{
    public class JobInformationConfiguration : IEntityTypeConfiguration<JobInformation>
    {
        public void Configure(EntityTypeBuilder<JobInformation> builder)
        {
            builder.ToTable("JobInformations");

            builder.HasKey(x=> x.JobInformationId);

            builder.Property(x=> x.JobInformationId).ValueGeneratedNever();

            builder.Property(x => x.JobTitle).IsRequired();

            builder.Property(x=> x.JobLevel).IsRequired();

            builder.Property(x => x.JobType).IsRequired();

            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.Requirements).IsRequired();

            builder.Property(x => x.WorkingLocation).IsRequired();

            builder.Property(x => x.MinSalary).IsRequired().HasDefaultValue(0);

            builder.Property(x => x.MaxSalary).IsRequired().HasDefaultValue(0);

            builder.Property(x => x.Salary).IsRequired().HasDefaultValue(0);

            builder.Property(x => x.Benefits).IsRequired();

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);

            builder.Property(x => x.JobInformationTimeStart);

            builder.Property(x => x.JobInformationTimeEnd);

            builder.HasOne(x=> x.Recruiter).WithMany(x=>x.JobInformation).HasForeignKey(x=>x.RecruiterId);

            builder.HasOne(x=> x.Job).WithMany(x=>x.JobInformation).HasForeignKey(x=>x.JobId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SaveJob).WithOne(x => x.JobInformation).HasForeignKey<SaveJob>(x => x.JobInformationId);

            builder.HasOne(x => x.ApplyJob).WithOne(x => x.JobInformation).HasForeignKey<ApplyJob>(x => x.JobInformationId);
        }
    }
}
