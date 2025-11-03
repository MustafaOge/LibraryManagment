using LibraryManagment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Data.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("PUBLISHER");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ID");

            builder.Property(p => p.PublisherName)
                .HasColumnName("PUBLISHER_NAME")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasDefaultValue(false);

            builder.Property(p => p.CreatedDate)
                .HasColumnName("CREATED_DATE")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Relationships
            builder.HasMany(p => p.Books)
                .WithOne(b => b.Publisher)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
