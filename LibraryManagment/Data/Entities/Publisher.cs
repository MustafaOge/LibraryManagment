using System.ComponentModel.DataAnnotations;

namespace LibraryManagment.Data.Entities
{
    // Publisher Entity
    public class Publisher : Entity<int>
    {
        [Required]
        public string PublisherName { get; set; } = null!;

        public DateTimeOffset CreatedDate { get; set; }

        // Navigation Properties
        public virtual ICollection<Book> Books { get; set; }
    }
}
