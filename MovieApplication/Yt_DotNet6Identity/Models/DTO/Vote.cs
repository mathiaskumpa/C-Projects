using MovieApp.Models.Domain;
using MovieApp.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models.DTO
{
    public class Vote
    {
        public int VoteId { get; set; } // Primary Key
        public string UserId { get; set; } // Foreign Key to User
        public long MovieId { get; set; } // Foreign Key to Movie
        [Range(1, 5, ErrorMessage = "Vote must be between 1 and 5")]
        public int Rating { get; set; }
        public DateTime VoteDate { get; set; }= DateTime.Now;

    }

}
