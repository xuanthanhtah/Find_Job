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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Dob).IsRequired();

            builder.HasOne(x => x.JobSeeker).WithOne(x => x.Users).HasForeignKey<JobSeeker>(x => x.UserId);

            builder.HasOne(x => x.Recruiter).WithOne(x => x.Users).HasForeignKey<Recruiter>(x => x.UserId);
        }
    }
}
