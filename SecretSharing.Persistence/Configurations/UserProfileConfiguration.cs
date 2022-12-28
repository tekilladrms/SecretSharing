using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecretSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Persistence.Configurations
{
    internal class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfile");
            builder.HasKey(userProfile => userProfile.Guid);
            builder.Property(userProfile => userProfile.Guid).ValueGeneratedNever();

            builder.OwnsOne(up => up.FirstName).Property(prop => prop.Value).HasColumnName("FirstName");
            builder.OwnsOne(up => up.LastName).Property(prop => prop.Value).HasColumnName("LastName");

            builder.HasMany(up => up.Documents).WithMany(d => d.Users).UsingEntity(e => e.ToTable("UsersDocument"));

            builder.HasMany<Document>().WithOne(d => d.Creator);
        }
    }
}
