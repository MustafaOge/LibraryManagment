using System.ComponentModel.DataAnnotations;

namespace LibraryManagment.Data.Entities
{
    public class Reader : AuditableEntity<int>
    {
        public string NationalId { get; set; }

        [Required]
        public string FullName { get; set; } = null!;

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public byte[] Image { get; set; }

        // Navigation Properties
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
