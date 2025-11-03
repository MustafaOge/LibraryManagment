using LibraryManagment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Data.Configurations
{
    public class UserCredentialConfiguration : IEntityTypeConfiguration<UserCredential>
    {
        public void Configure(EntityTypeBuilder<UserCredential> builder)
        {
            builder.ToTable("USER_CREDENTIAL");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("ID");

            builder.Property(c => c.UserId)
                .HasColumnName("USER_ID")
                .IsRequired();

            builder.HasIndex(c => c.UserId)
                .IsUnique();

            builder.Property(c => c.PasswordHash)
                .HasColumnName("PASSWORD_HASH")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.PasswordSalt)
                .HasColumnName("PASSWORD_SALT")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.CreatedDate)
                .HasColumnName("CREATED_DATE")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.ModifiedDate)
                .HasColumnName("MODIFIED_DATE");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserCredentials)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_CREDENTIAL_USER");

        }
    }
}