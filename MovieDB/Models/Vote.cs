using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Vote
    {
        [Key]
        public int VoteID { get; set; }

        // Foreign key properties
        public int MovieID { get; set; }
        public int UserID { get; set; }

        [Range(1, 5)]
        public int RatingValue { get; set; }

        [Required]
        public DateTime VoteDate { get; set; }
        public string Email { get; set; }
        // Navigation properties for the Movie and User relationships
        public Movie Movie { get; set; }
        public User User { get; set; }
        
    }
}
