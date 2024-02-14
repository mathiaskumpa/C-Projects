namespace MovieDatabase.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public Movie()
        {
            Ratings = new HashSet<MovieRating>();
        }

        public virtual ICollection<MovieRating> Ratings { get; set; }
    }
}
