using System.ComponentModel.DataAnnotations;

namespace LibraryManagment.Data.Entities
{
    public class Book : AuditableEntity<int>
    {
        [Required]
        public string Barcode { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        public int? AuthorId { get; set; }

        public int? PublisherId { get; set; }

        public string BookType { get; set; } 

        public string Description { get; set; } 

        public string PrintLocation { get; set; } 

        public int? PrintNumber { get; set; }

        public string PrintDate { get; set; }

        public string AcquisitionType { get; set; }

        public string AcquisitionDate { get; set; }

        public int? PageCount { get; set; }

        public byte[] Image { get; set; }

        public bool IsLoaned { get; set; }

        // Navigation Properties
        public virtual Author Author { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }

}
