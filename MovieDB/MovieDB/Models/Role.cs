using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Role
    {

        [Key]
        public int RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }

        // Navigation property for the UserRole relationship
        public List<UserRole> UserRoles { get; set; }
    }
}
