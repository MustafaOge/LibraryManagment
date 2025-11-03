using System.ComponentModel.DataAnnotations;

namespace LibraryManagment.Data.Entities
{
    public class Loan : AuditableEntity<int>
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int ReaderId { get; set; }

        [Required]
        public DateTimeOffset LoanDate { get; set; }

        public DateTimeOffset? ReturnDate { get; set; }

        public int Status { get; set; }

        // Navigation Properties
        public virtual Book Book { get; set; }

        public virtual Reader Reader { get; set; }
    }
}
