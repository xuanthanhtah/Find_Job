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
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");

            builder.HasKey(x => x.SkillId);

            builder.Property(x => x.SkillId).UseIdentityColumn();

            builder.Property(x => x.SchoolName);

            builder.Property(x => x.Degree);

            builder.Property(x => x.Certificate);

            builder.Property(x => x.Language);

            builder.Property(x => x.level);

        }
    }
}
