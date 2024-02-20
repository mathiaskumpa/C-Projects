using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }

        // Foreign key property
        public int MovieID { get; set; }

        [Required]
        public string Source { get; set; }

        public double Score { get; set; }

        public string Review { get; set; }

        // Navigation property for the Movie relationship
        public Movie Movie { get; set; }
    }
}
