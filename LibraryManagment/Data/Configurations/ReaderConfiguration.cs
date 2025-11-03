using LibraryManagment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Data.Configurations
{
    public class ReaderConfiguration : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder.ToTable("READER");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("ID");

            builder.Property(r => r.NationalId)
                .HasColumnName("NATIONAL_ID")
                .HasMaxLength(11);

            builder.HasIndex(r => r.NationalId)
                .IsUnique();

            builder.Property(r => r.FullName)
                .HasColumnName("FULL_NAME")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(r => r.Address)
                .HasColumnName("ADDRESS")
                .HasMaxLength(500);

            builder.Property(r => r.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100);

            builder.Property(r => r.Phone)
                .HasColumnName("PHONE")
                .HasMaxLength(20);

            builder.Property(r => r.Image)
                .HasColumnName("IMAGE")
                .HasColumnType("bytea");

            builder.Property(r => r.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasDefaultValue(false);

            builder.Property(r => r.CreatedDate)
                .HasColumnName("CREATED_DATE")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(r => r.ModifiedDate)
                .HasColumnName("MODIFIED_DATE");

            builder.Property(r => r.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder.Property(r => r.ModifiedBy)
                .HasColumnName("MODIFIED_BY");

            // Relationships
            builder.HasMany(r => r.Loans)
                .WithOne(l => l.Reader)
                .HasForeignKey(l => l.ReaderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
