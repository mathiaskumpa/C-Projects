using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class ProductionCompany
    {
        [Key]
        public int CompanyID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        // Navigation property for the Movies relationship
        public List<Movie> Movies { get; set; }
    }
}
