using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database connection
var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "../data/inflation-feed.db");
var connectionString = $"Data Source={dbPath}";

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite(connectionString));
var app = builder.Build();

app.MapGet("/prices", async (AppDbContext db) => 
    await db.Prices.ToListAsync());

app.Run();

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Price> Prices { get; set; }
}

public class Price
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Store { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
