using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        public required string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }

        public required string Language { get; set; }
        public string UploadPath { get; set; }
        // Navigation properties for relationships
        public int GenreID { get; set; }
        public Genre Genre { get; set; }

        public int DirectorID { get; set; }
        public Director Director { get; set; }

        // Other relationships and properties...

        // Navigation property for the Ratings relationship
        // public List<global::Rating> Ratings { get; set; }

        // Navigation property for the Votes relationship
        public List<Vote> Votes { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
