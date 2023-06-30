using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations
{
    public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("PropertyImage");
            builder.Property(e => e.Id).HasColumnName("IdPropertyImage");
            builder.HasKey(e => e.Id).HasName("PK_PropertyImage");
            builder.HasIndex(e => e.Id, "PK_PropertyImage").IsUnique();

            builder.Property(e => e.FileUrl)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasOne(d => d.IdPropertyNavigation)
                .WithMany(p => p.PropertyImages)
                .HasForeignKey(d => d.IdProperty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PropertyImage_Property");
        }
    }
}
