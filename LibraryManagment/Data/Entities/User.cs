using System.ComponentModel.DataAnnotations;

namespace LibraryManagment.Data.Entities
{
    public class User : Entity<int>
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string Username { get; set; } = null!;
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Title { get; set; }
    
        public virtual ICollection<UserCredential> UserCredentials { get; } = new List<UserCredential>(); 
    }
}
