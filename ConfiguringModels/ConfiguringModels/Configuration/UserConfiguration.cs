using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringModels.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id).HasName("UserId");
            builder.HasIndex(x => x.Gender).HasDatabaseName("GenderUsers");
            builder.ToTable("Users");
            builder.Property(x => x.Gender).IsRequired();
        }
    }
}
