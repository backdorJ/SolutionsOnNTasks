using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owned.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owned.ApplicationContext
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(X => X.Id).HasName("UserId");
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Age).HasDefaultValue(18);
            builder.ToTable("Peoples");
            builder.OwnsOne(typeof(ProfileUser), "Portfolio");
        }
    }
}
