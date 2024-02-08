using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }


        public required string FirstName { get; set; }


        public required string LastName { get; set; }

        public DateTime BirthDate { get; set; }


        public required string Nationality { get; set; }

        // Navigation property for the Characters relationship
        //public List<global::Character> Characters { get; set; }

    }
}
