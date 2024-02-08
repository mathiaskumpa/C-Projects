using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Director
    {
        [Key]
        public int DirectorID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Nationality { get; set; }

        // Navigation property for the Movies relationship
        public List<Movie> Movies { get; set; }
    }
}
