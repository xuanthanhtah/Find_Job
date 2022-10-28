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
    public class JobSeeekerConfiguration : IEntityTypeConfiguration<JobSeeker>
    {
        public void Configure(EntityTypeBuilder<JobSeeker> builder)
        {
            builder.ToTable("JobSeekers");

            builder.HasKey(x => x.JobSeekerId);

            builder.Property(x => x.JobSeekerId).UseIdentityColumn();

            builder.Property(x=> x.Address);

            builder.Property(x=> x.Gender).HasMaxLength(6);

            builder.Property(x => x.National);

            builder.Property(x => x.DesiredSalary);

            builder.Property(x => x.Image);

            builder.HasOne(x => x.Job).WithMany(x=>x.JobSeekers).HasForeignKey(x=>x.JobId);
        }
    }
}
