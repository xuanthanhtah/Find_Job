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
    public class SaveJobConfiguration : IEntityTypeConfiguration<SaveJob>
    {
        public void Configure(EntityTypeBuilder<SaveJob> builder)
        {
            builder.ToTable("SaveJobs");

            builder.HasKey(x => x.SaveJobId);

            builder.Property(x => x.SaveJobId).UseIdentityColumn();

            builder.HasOne(x => x.JobInformation).WithOne(x => x.SaveJob).HasForeignKey<JobInformation>(x => x.SaveJobId);
        }
    }
}
