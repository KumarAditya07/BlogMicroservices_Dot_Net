namespace BlogMicroservice.BlogService.DTOs
{
    public class PageRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Search { get; set; }

        public string? SortBy { get; set; } = "publishedOn"; // Default sort by "publishedOn

        public string? SortDirection { get; set; } = "desc"; // Default sort direction is "desc

    }
}
