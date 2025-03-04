using BlogMicroservice.AuthService.Models;

namespace BlogMicroservice.AuthService.Services
{
    public interface ITokenService
    {
        Task<string> GenerateAccessToken(ApplicationUser user); 
    }
}
