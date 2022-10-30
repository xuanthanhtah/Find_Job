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
    public class ApplyJobConfiguration : IEntityTypeConfiguration<ApplyJob>
    {
        public void Configure(EntityTypeBuilder<ApplyJob> builder)
        {
            builder.ToTable("ApplyJobs");

            builder.HasKey(x => new { x.JobSeekerId, x.JobInformationId });

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);

            builder.Property(x => x.TimeApply);

            builder.HasOne(x => x.JobSeeker).WithMany(x => x.ApplyJobs).HasForeignKey(x => x.JobSeekerId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.JobInformation).WithMany(x => x.ApplyJobs).HasForeignKey(x => x.JobInformationId);
        }
    }
}
