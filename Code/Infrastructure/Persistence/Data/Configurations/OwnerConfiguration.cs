using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations
{
    class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");

            builder.Property(e => e.Id).HasColumnName("IdOwner");
            builder.HasKey(e => e.Id).HasName("PK_Owner");
            builder.HasIndex(e => e.Id, "PK_Owner").IsUnique();

            builder.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Birthday).HasColumnType("date");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Photo)
                .HasMaxLength(200)
                .IsUnicode(false);

        }
    }
}
