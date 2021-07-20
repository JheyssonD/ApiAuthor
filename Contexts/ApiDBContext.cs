using ApiAuthor.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiAuthor.Contexts
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
    }
}
