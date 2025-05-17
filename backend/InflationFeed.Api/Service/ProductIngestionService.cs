using System.Globalization;
using InflationFeed.Api.Data;

public class ProductIngestionService
{
    private readonly AppDbContext _db;

    public ProductIngestionService(AppDbContext db)
    {
        _db = db;
    }

    public async Task IngestAsync(ProductIngestionDto dto)
    {
        decimal ParsePrice(string price) =>
            decimal.TryParse(price.Replace("$", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out var val) ? val : 0;

        var product = new Product
        {
            ProductId = int.Parse(dto.ProductId),
            Name = dto.Name,
            Brand = dto.Brand,
            Category = dto.Category,
            SkuId = dto.SkuId,
            ListPrice = ParsePrice(dto.ListPrice),
            SalePrice = ParsePrice(dto.SalePrice),
            UnitListPrice = ParsePrice(dto.UnitListPrice),
            Unit = dto.Unit,
            IsOnSale = dto.IsOnSale,
            Date = DateTime.SpecifyKind(DateTime.Parse(dto.Date, CultureInfo.InvariantCulture), DateTimeKind.Utc)
        };

        _db.Products.Add(product);
        await _db.SaveChangesAsync();
    }
}