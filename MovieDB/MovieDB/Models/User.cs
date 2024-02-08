using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        // Navigation properties for the Votes relationship
        public List<Vote> Votes { get; set; }
    }
}
