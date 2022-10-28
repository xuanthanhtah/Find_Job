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
    public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
    {
        public void Configure(EntityTypeBuilder<Recruiter> builder)
        {
            builder.ToTable("Recruiters");

            builder.HasKey(x => x.RecruiterId);

            builder.Property(x => x.RecruiterId).UseIdentityColumn();

            builder.Property(x => x.CompanyName);

            builder.Property(x => x.CompanyLogo);
            
            builder.Property(x => x.Address);

            builder.Property(x => x.CompanyIntroduction);
        }
    }
}
