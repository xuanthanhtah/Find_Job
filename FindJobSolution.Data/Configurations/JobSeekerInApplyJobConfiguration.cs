using FindJobSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Configurations
{
    public class JobSeekerInApplyJobConfiguration : IEntityTypeConfiguration<JobSeekerInApplyJob>
    {
        public void Configure(EntityTypeBuilder<JobSeekerInApplyJob> builder)
        {
            builder.HasKey(x=> new { x.ApplyJobsId, x.JobSeekerId});

            builder.ToTable("JobSeekerInApplyJobs");

            builder.HasOne(x => x.JobSeeker).WithMany(ja => ja.jobSeekerInApplyJobs).HasForeignKey(x=>x.JobSeekerId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ApplyJob).WithMany(ja => ja.jobSeekerInApplyJobs).HasForeignKey(x=>x.ApplyJobsId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ApplyJobsTime).HasDefaultValue(DateTime.Now);
        }
    }
}
