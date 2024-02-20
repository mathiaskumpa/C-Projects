using Microsoft.AspNetCore.Identity;
using MovieApp.Models.DTO;

namespace MovieApp.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? ProfilePicture { get; set; }
        // Navigation property for Votes cast by this Use

    }
}
