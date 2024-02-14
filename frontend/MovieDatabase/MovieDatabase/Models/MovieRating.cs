using Microsoft.AspNetCore.Identity;

namespace MovieDatabase.Models
{
    public class MovieRating
    {
        public long Id { get; set; }
        public short Rating { get; set; } = 0;
        public virtual long MovieId { get; set; }
        public virtual long UserId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public MovieRating()
        {
        }

        public virtual Movie? Movie { get; set; }
        public IdentityUser User { get; set; }
    }
}
