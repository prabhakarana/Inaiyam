using System;
using System.Text.RegularExpressions;

namespace Inaiyam.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string AuthorId { get; set; } = string.Empty;
        public string Status { get; set; } = "Draft";

        public static string GenerateSlug(string title)
        {
            title = title.ToLowerInvariant();
            title = Regex.Replace(title, "[^a-z0-9\s-]", "");
            title = Regex.Replace(title, "\s+", " ").Trim();
            title = title[..Math.Min(title.Length, 45)].Trim();
            title = Regex.Replace(title, "\s", "-");
            return title;
        }
    }
}
