using Microsoft.AspNetCore.Identity;

namespace BlogMicroservice.AuthService.Models
{

    /*
     * ApplicationUser is a custom user model for ASP.NET Core Identity.
       It inherits from IdentityUser, which means:
        It already includes properties like Username, Email, PasswordHash, PhoneNumber, etc.
         You can extend it by adding custom properties.
     */
    public class ApplicationUser : IdentityUser
    {

    }
}
