using System.Threading.Tasks;
using Inaiyam.Data;
using Inaiyam.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Inaiyam.Tests
{
    public class PostsTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "PostsTestDb")
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task CanCreatePost()
        {
            using var context = GetDbContext();
            var post = new Post { Title = "Test", Content = "Body" };
            post.Slug = Post.GenerateSlug(post.Title);
            context.Posts.Add(post);
            await context.SaveChangesAsync();

            Assert.Equal(1, await context.Posts.CountAsync());
            Assert.Equal("test", (await context.Posts.FirstAsync()).Slug);
        }

        [Fact]
        public void SlugGeneration_Works()
        {
            var slug = Post.GenerateSlug("Hello World!");
            Assert.Equal("hello-world", slug);
        }
    }
}
