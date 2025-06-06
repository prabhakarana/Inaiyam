using Microsoft.EntityFrameworkCore;
using Inaiyam.Models;

namespace Inaiyam.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts => Set<Post>();
    }
}
