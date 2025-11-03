using LibraryManagment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("AUTHOR");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("ID");

            builder.Property(a => a.FullName)
                .HasColumnName("FULL_NAME")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(a => a.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasDefaultValue(false);

            builder.Property(a => a.CreatedDate)
                .HasColumnName("CREATED_DATE")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
