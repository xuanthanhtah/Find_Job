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
    public class JobSeekerOldCompanyConfiguration : IEntityTypeConfiguration<JobSeekerOldCompany>
    {
        public void Configure(EntityTypeBuilder<JobSeekerOldCompany> builder)
        {
            builder.ToTable("JobSeekerOldCompanys");

            builder.HasKey(x => x.JobSeekerOldCompanyId);

            builder.Property(x => x.JobSeekerOldCompanyId).UseIdentityColumn();

            builder.Property(x => x.CompanyName).IsRequired();

            builder.Property(x => x.JobTitle).IsRequired();

            builder.Property(x => x.WorkExperience).IsRequired();

            builder.HasOne(x => x.JobSeeker).WithMany(x => x.JobSeekerOldCompanies).HasForeignKey(x => x.JobSeekerId);
        }
    }
}
