using Microsoft.EntityFrameworkCore;

namespace InflationFeed.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Models.Price> Prices { get; set; }
    }

    
}