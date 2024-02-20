namespace MovieApp.Models.DTO
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; } = "";

        public string Password { get; set; }
    }
}
