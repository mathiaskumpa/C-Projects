using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MovieDB.Utils
{
    public class JWTHelper
    {
        private const  string SecretKey = "2f35257d34945a2f4a5f4a1e273f2a0b2f3e7e4a0e0e0a77272a1e4a5e3a6e1f2a7a8a8f9f4c3d2e2a1e4a8f2a8a4a9a2a3a8a3f4e6c2a2a3a5a5a5a6e1f4c3d2e2a1e4a8f2a8a4a9a2a3a8a3f4e6c2a2a3a5a5a5a6e1"; // 
        private static readonly SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(SecretKey));

        public static string GenerateJwtToken(string userId, string username)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: "moviedb.com",
                audience: "someaudience",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static ClaimsPrincipal VerifyJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "moviedb.com",
                    ValidAudience = "someaudience",
                    IssuerSigningKey = SecurityKey,
                    ClockSkew = TimeSpan.Zero 
                }, out var validatedToken);
       
                return principal;
            }
            catch (SecurityTokenException)
            {
                return null;
            }

        }
        public static string GenerateSecretKey(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[length];
                rng.GetBytes(bytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}


