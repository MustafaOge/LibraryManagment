using LibraryManagment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Data.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("LOAN");

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("ID");

            builder.HasIndex(l => l.BookId);
            builder.HasIndex(l => l.ReaderId);
            builder.HasIndex(l => l.LoanDate);

            builder.Property(l => l.BookId)
                .HasColumnName("BOOK_ID")
                .IsRequired();

            builder.Property(l => l.ReaderId)
                .HasColumnName("READER_ID")
                .IsRequired();

            builder.Property(l => l.LoanDate)
                .HasColumnName("LOAN_DATE")
                .IsRequired();

            builder.Property(l => l.ReturnDate)
                .HasColumnName("RETURN_DATE");

            builder.Property(l => l.Status)
                .HasColumnName("STATUS")
                .HasDefaultValue(0);

            builder.Property(l => l.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasDefaultValue(false);

            builder.Property(l => l.CreatedDate)
                .HasColumnName("CREATED_DATE")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(l => l.ModifiedDate)
                .HasColumnName("MODIFIED_DATE");

            builder.Property(l => l.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder.Property(l => l.ModifiedBy)
                .HasColumnName("MODIFIED_BY");

            // Relationships
            builder.HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Reader)
                .WithMany(r => r.Loans)
                .HasForeignKey(l => l.ReaderId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
