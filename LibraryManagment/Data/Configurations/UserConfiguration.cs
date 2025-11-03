using LibraryManagment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USER");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("ID");

            builder.Property(u => u.FullName)
                .HasColumnName("FULL_NAME")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.Username)
                .HasColumnName("USERNAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100);

            builder.Property(u => u.Phone)
                .HasColumnName("PHONE")
                .HasMaxLength(20);

            builder.Property(u => u.Title)
                .HasColumnName("TITLE")
                .HasMaxLength(100);
        }
    }
}
