using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations
{
    public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.ToTable("PropertyTrace");

            builder.Property(e => e.Id).HasColumnName("IdPropertyTrace");
            builder.HasKey(e => e.Id).HasName("PK_PropertyTrace");
            builder.HasIndex(e => e.Id, "PK_PropertyTrace").IsUnique();

            builder.Property(e => e.DateSale).HasColumnType("date");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.IdPropertyNavigation)
                .WithMany(p => p.PropertyTraces)
                .HasForeignKey(d => d.IdProperty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PropertyTrace_Property");
        }
    }
}
