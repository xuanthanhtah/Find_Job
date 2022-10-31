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
    public class RecruiterImagesConfiguration : IEntityTypeConfiguration<RecruiterImages>
    {
        public void Configure(EntityTypeBuilder<RecruiterImages> builder)
        {
            builder.ToTable("RecruiterImages");

            builder.HasKey(x => x.RecruiterGalleriesId);

            builder.Property(x => x.RecruiterGalleriesId).UseIdentityColumn();

            builder.Property(x => x.FilePath).IsRequired(true);

            builder.HasOne(x => x.Recruiter).WithMany(x => x.recruiterGalleries).HasForeignKey(x => x.RecruiterId);

            builder.Property(x => x.DateCreated);

            builder.Property(x => x.FileSize);

            builder.Property(x => x.Caption);

            builder.Property(x => x.IsDefault);

            builder.Property(x => x.SortOrder);
        }
    }
}