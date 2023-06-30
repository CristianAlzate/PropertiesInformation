using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.Data.Configurations;
public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {

        builder.ToTable("Property");

        builder.Property(e => e.Id).HasColumnName("IdProperty");
        builder.HasKey(e => e.Id).HasName("PK_Property");
        builder.HasIndex(e => e.Id, "PK_Property").IsUnique();

        builder.Property(e => e.Address)
            .HasMaxLength(200)
            .IsUnicode(false);

        builder.Property(e => e.CodeInternal)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsUnicode(false);

        builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");

        builder.HasOne(d => d.IdOwnerNavigation)
            .WithMany(p => p.Properties)
            .HasForeignKey(d => d.IdOwner)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Property_Owner");
    }
}
