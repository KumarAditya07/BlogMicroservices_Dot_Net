using BlogMicroservice.AuthService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogMicroservice.AuthService.Data
{
    /*
     AuthDbContext is a database context (DbContext) that handles user authentication and authorization.
     It inherits from IdentityDbContext<ApplicationUser>, which means:  
     It includes tables for users, roles, and authentication.
     It automatically provides built-in login, registration, password hashing, and role management.
     */

    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {

        /*
         *DbContextOptions is a configuration object that tells Entity Framework which database to use.
           It is passed to the base constructor (: base(options)) so Entity Framework Core can use it.
         */
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
    }

}
