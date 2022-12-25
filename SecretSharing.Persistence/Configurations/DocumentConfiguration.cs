using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecretSharing.Domain.Entities;

namespace SecretSharing.Persistence.Configurations
{
    internal class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Document");
            builder.HasKey(document => document.Guid);

            builder.Property(document => document.Guid).ValueGeneratedNever();

            builder.OwnsOne(document => document.Name).Property(prop => prop.Value).HasColumnName("Name");

            builder.HasMany(doc => doc.Users).WithMany(up => up.Documents).UsingEntity(x => x.ToTable("UsersDocument"));
        }
    }
}
