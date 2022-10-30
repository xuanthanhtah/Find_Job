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
    public class SaveJobConfiguration : IEntityTypeConfiguration<SaveJob>
    {
        public void Configure(EntityTypeBuilder<SaveJob> builder)
        {
            builder.ToTable("SaveJobs");

            builder.HasKey(x => new { x.JobSeekerId, x.JobInformationId });

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);

            builder.Property(x => x.TimeSave);

            builder.HasOne(x => x.JobSeeker).WithMany(x => x.SaveJobs).HasForeignKey(x => x.JobSeekerId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.JobInformation).WithMany(x => x.SaveJobs).HasForeignKey(x => x.JobInformationId);
        }
    }
}
