using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {}

        public DbSet<Product> Products { get; set; }
    }
}