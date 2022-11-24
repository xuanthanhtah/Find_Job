using FindJobSolution.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Configurations
{
    public class MessageCongiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id).UseIdentityColumn();

            builder.Property(x => x.userName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.text).IsRequired().HasMaxLength(500);

            builder.Property(x => x.date).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.messages).HasForeignKey(x => x.userId);
        }
    }
}