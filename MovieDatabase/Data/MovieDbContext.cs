using Microsoft.EntityFrameworkCore;
using MovieDB.Models;

namespace MovieDB.Data
{
    public class MovieDbContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Role> Roles { get; set; }
       

        // Add any other DbSet properties as needed

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        // Add any additional configuration or methods here
    }
}


