using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation property for the Movies relationship
        public List<Movie> Movies { get; set; }
    }
}
