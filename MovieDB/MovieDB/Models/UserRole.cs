using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class UserRole
    {

        [Key]
        public int UserRoleID { get; set; }

        // Foreign key properties
        public int UserID { get; set; }
        public int RoleID { get; set; }

        // Navigation properties for the User and Role relationships
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
