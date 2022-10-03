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
    public class JobSeekerSkillConfiguration : IEntityTypeConfiguration<JobSeekerSkill>
    {
        public void Configure(EntityTypeBuilder<JobSeekerSkill> builder)
        {
            builder.HasKey(x => new { x.SkillId, x.JobSeekerId });

            builder.ToTable("JobSeekerSkills");

            builder.HasOne(x => x.Skill).WithMany(x => x.JobSeekerSkills).HasForeignKey(x => x.SkillId);

            builder.HasOne(x => x.JobSeeker).WithMany(x => x.JobSeekerSkills).HasForeignKey(x => x.JobSeekerId);
        }
    }
}
