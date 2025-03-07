using BlogMicroservice.BlogService.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMicroservice.BlogService.Data
{
    public class BlogServiceContext : DbContext
    {
        public BlogServiceContext(DbContextOptions<BlogServiceContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

      
    }   
    
}
