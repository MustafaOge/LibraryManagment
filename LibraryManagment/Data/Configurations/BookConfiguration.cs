using LibraryManagment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("BOOK");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("ID");

            builder.Property(b => b.Barcode)
                .HasColumnName("BARCODE")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(b => b.Barcode)
                .IsUnique();

            builder.Property(b => b.Title)
                .HasColumnName("TITLE")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(b => b.AuthorId)
                .HasColumnName("AUTHOR_ID");

            builder.Property(b => b.PublisherId)
                .HasColumnName("PUBLISHER_ID");

            builder.Property(b => b.BookType)
                .HasColumnName("BOOK_TYPE")
                .HasMaxLength(100);

            builder.Property(b => b.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(2000);

            builder.Property(b => b.PrintLocation)
                .HasColumnName("PRINT_LOCATION")
                .HasMaxLength(200);

            builder.Property(b => b.PrintNumber)
                .HasColumnName("PRINT_NUMBER");

            builder.Property(b => b.PrintDate)
                .HasColumnName("PRINT_DATE")
                .IsRequired(false);

            builder.Property(b => b.AcquisitionType)
                .HasColumnName("ACQUISITION_TYPE")
                .HasMaxLength(100);

            builder.Property(b => b.AcquisitionDate)
                .HasColumnName("ACQUISITION_DATE")
                .IsRequired(false);

            builder.Property(b => b.PageCount)
                .HasColumnName("PAGE_COUNT");

            builder.Property(b => b.Image)
                .HasColumnName("IMAGE")
                .HasColumnType("bytea");

            builder.Property(b => b.IsLoaned)
                .HasColumnName("IS_LOANED")
                .HasDefaultValue(false);

            builder.Property(b => b.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasDefaultValue(false);

            builder.Property(b => b.CreatedDate)
                .HasColumnName("CREATED_DATE")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(b => b.ModifiedDate)
                .HasColumnName("MODIFIED_DATE");

            builder.Property(b => b.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder.Property(b => b.ModifiedBy)
                .HasColumnName("MODIFIED_BY");

            // Relationships
            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.Loans)
                .WithOne(l => l.Book)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
