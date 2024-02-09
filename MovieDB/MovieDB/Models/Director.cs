using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Director
    {
        [Key]
        public int DirectorID { get; set; }

        public string FirstName { get; set; }

       
        public string LastName { get; set; }

        
        public DateTime BirthDate { get; set; }

       
        public string Nationality { get; set; }

        // Navigation property for the Movies relationship
        public List<Movie> Movies { get; set; }
    }
}
