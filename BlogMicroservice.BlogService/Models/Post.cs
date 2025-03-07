using System.ComponentModel.DataAnnotations.Schema;

namespace BlogMicroservice.BlogService.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string? Labels { get; set; } // comma separated labels/tags

        public DateTime PublishedOn { get; set; } = DateTime.UtcNow;

        public string? Permalink { get; set; }

        public string? Location { get; set; }

        public string? SearchDescription { get; set; }

        public string AuthorId { get; set; } = string.Empty;

        [NotMapped] // Optional, if Author details are fetched separately
       // public ApplicationUser? Author { get; set; }

        public bool AllowComments { get; set; } = true;

    }
}
