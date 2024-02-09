using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDB.Data;
using MovieDB.Models;
using System.Text;
using System.Security.Cryptography;
using MovieDB.Utils; 

public class LoginPayLoad 
{ 
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class Session 
{
    public string token { get;  set; }
    public User user { get; set; }
}
public class NewUser
{
    public int RoleID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime RegistrationDate { get; set; }
}

namespace MovieDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly object token;

        public UsersController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        //Login
        [HttpPost("Login")]
        public async Task<ActionResult<Session>> LoginUser(LoginPayLoad payload)
        {
            var user= await _context.Users.FirstOrDefaultAsync(u => u.UserName == payload.UserName);
            if (user == null)
            {
                return BadRequest();
            }
            bool isValidPassword = VerifyPassword(payload.Password, user.Password);
            if (!isValidPassword)
            {
                return BadRequest("Incorrect userName and Password");
            }
            return new Session
            {
                token = JWTHelper.GenerateJwtToken(user.UserID.ToString(), user.UserName ),
                user =user
            };
            
        }
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(NewUser payload)
        {
            var user = new User
            {
                RoleID = payload.RoleID,
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                RegistrationDate = payload.RegistrationDate,
                Email = payload.Email,
                UserName = payload.UserName,
                Password = HashPassword(payload.Password)
            };

            var userExist =  DoesUserExist(user.Email, user.UserName);
            if(userExist)
            {
                return BadRequest();
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }
        private bool DoesUserExist(string email, string username)
        {
            bool userExistsByEmail = _context.Users.Any(u => u.Email == email);
            bool userExistsByUsername = _context.Users.Any(u => u.UserName == username);

            return userExistsByEmail || userExistsByUsername;
        }


        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            string hashedInputPassword = HashPassword(inputPassword);
            return string.Equals(hashedInputPassword, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
