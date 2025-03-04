using BlogMicroservice.AuthService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogMicroservice.AuthService.Services
{
    public class TokenService : ITokenService
    {

        /*
         * 1. Add Claims	Stores user ID, email, and roles in the JWT payload
         2. Add Roles	Gets user roles from _userManager and adds them to claims
         3. Create Secure Key	Uses Jwt:Key from appsettings.json for encryption
         4. Create Signing Credentials	Uses HMAC SHA256 to sign the JWT
         5. Generate JWT Token	Creates a JWT with issuer, audience, claims, and expiry
         6. Return JWT as String	Converts JWT to a string and returns it
         */

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public TokenService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<string> GenerateAccessToken(ApplicationUser AppUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,AppUser.Id),
                new Claim(JwtRegisteredClaimNames.Email, AppUser.Email)
            };

            var roles = await _userManager.GetRolesAsync(AppUser);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                              null,null,
                               claims,
                               expires: DateTime.UtcNow.AddDays(3),
                                signingCredentials: creds
                            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}
