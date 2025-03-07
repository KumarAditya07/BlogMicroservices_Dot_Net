using BlogMicroservice.BlogService.Data;
using BlogMicroservice.BlogService.DTOs;
using BlogMicroservice.BlogService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogMicroservice.BlogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly BlogServiceContext _context;

        [HttpGet(ApiEndpoints.BlogApiEndpoints.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery]PageRequest request)
        {

            var query = _context.Posts.AsQueryable();
            if(!string.IsNullOrWhiteSpace(request.Search))
            {
                query = query.Where(p => p.Title.Contains(request.Search) 
                  || p.Content.Contains(request.Search)
                    || p.Labels.Contains(request.Search));

            }
            query = request.SortBy?.ToLower() switch
            {
                "title" => request.SortDirection?.ToLower() == "asc" ? query.OrderBy(p => p.Title) : query.OrderByDescending(p => p.Title),
              
                _ => request.SortDirection?.ToLower() == "asc" ? query.OrderBy(p => p.PublishedOn) : query.OrderByDescending(p => p.PublishedOn)
            };  
            var toatlItems = await query.CountAsync();
            var posts = await query.Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return Ok(new 
            {
                toatlItems,
                request.Page,
                request.PageSize,
                posts
            });

        }
    }
}
