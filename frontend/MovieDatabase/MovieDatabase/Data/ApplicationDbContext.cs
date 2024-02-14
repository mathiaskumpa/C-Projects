using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Models;

namespace MovieDatabase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MovieDatabase.Models.Movie> Movie { get; set; } = default!;
        public DbSet<MovieDatabase.Models.MovieRating> MovieRating { get; set; } = default!;
    }
}
