using Microsoft.EntityFrameworkCore;

namespace InflationFeed.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (tableName is not null)
                {
                    entity.SetTableName(tableName.ToLower());
                }

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToLower());
                }
            }
        }

        public DbSet<Models.Price> Prices { get; set; }
    }

    
}