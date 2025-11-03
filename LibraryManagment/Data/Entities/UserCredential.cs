using System.ComponentModel.DataAnnotations;

namespace LibraryManagment.Data.Entities
{
    public class UserCredential : Entity<int>
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string PasswordSalt { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }

        public virtual User User { get; set; }
    }
}
