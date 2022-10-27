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
    public class JobSeekerInSaveJobConfiguration : IEntityTypeConfiguration<JobSeekerInSaveJob>
    {
        public void Configure(EntityTypeBuilder<JobSeekerInSaveJob> builder)
        {
            builder.HasKey(x => new { x.JobSeekerId, x.SaveJobId });

            builder.ToTable("JobSeekerInSaveJobs");

            builder.HasOne(x => x.JobSeeker).WithMany(x=> x.JobSeekerInSaveJobs).HasForeignKey(x=>x.JobSeekerId);

            builder.HasOne(x => x.SaveJob).WithMany(x=> x.JobSeekerInSaveJobs).HasForeignKey(x=>x.SaveJobId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.TimeSaveJob);
        }
    }
}
