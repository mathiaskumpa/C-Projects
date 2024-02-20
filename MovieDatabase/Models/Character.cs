using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Character
    {
        [Key]
        public int CharacterID { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        // Foreign key properties
        public int ActorID { get; set; }
        public int MovieID { get; set; }

        // Navigation properties for relationships
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
