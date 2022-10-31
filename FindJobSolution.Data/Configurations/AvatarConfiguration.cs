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
    public class AvatarConfiguration : IEntityTypeConfiguration<Avatar>
    {
        public void Configure(EntityTypeBuilder<Avatar> builder)
        {
            builder.ToTable("Avatars");

            builder.HasKey(x => x.AvatarId);

            builder.Property(x => x.AvatarId).UseIdentityColumn();

            builder.Property(x => x.Caption);

            builder.Property(x => x.FileSize);

            builder.Property(x => x.Timespan);

            builder.Property(x => x.SortOrder);

            builder.Property(x => x.IsDefault);

            builder.Property(x => x.FilePath);
        }
    }
}