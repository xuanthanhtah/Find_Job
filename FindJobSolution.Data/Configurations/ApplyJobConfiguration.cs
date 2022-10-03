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
            //builder.ToTable("ApplyJobs");

            builder.HasKey(x => x.ApplyJobsId);

            builder.Property(x => x.ApplyJobsId).UseIdentityColumn();

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);

            builder.HasOne(x => x.JobInformation).WithOne(x => x.ApplyJob).HasForeignKey<JobInformation>(x => x.ApplyJobsId);
        }
    }
}
