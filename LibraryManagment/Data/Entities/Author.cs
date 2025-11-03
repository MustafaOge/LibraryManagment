using System.ComponentModel.DataAnnotations;

namespace LibraryManagment.Data.Entities
{
    public class Author : Entity<int>
    {
        [Required]
        public string FullName { get; set; } = null!;

        public DateTimeOffset CreatedDate { get; set; }

        // Navigation Properties
        public virtual ICollection<Book> Books { get; set; }
    }
}
