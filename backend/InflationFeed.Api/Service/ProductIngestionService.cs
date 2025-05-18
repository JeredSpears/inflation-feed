using System.Globalization;
using InflationFeed.Api.Data;
using System.Text.Json;
using InflationFeed.Api.Data.Dto;

namespace InflationFeed.Api.Service
{
    public class ProductIngestionService(AppDbContext db)
    {
        private readonly AppDbContext _db = db;
        
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private static decimal ParsePrice(string price) =>
            decimal.TryParse(price?.Replace("$", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out var val) ? val : 0;

        public async Task<int> IngestAsync(string json)
        {
            List<ProductIngestionDto>? dtos;
            try
            {
                dtos = JsonSerializer.Deserialize<List<ProductIngestionDto>>(json, _jsonOptions);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid JSON format.", ex);
            }

            if (dtos == null || dtos.Count == 0)
                throw new ArgumentException("No valid product data found in JSON.");

            int count = 0;
            foreach (var dto in dtos)
            {
                Validate(dto);

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
                //TODO: return something better than count like which productIds were inserted?
                count++;
            }

            await _db.SaveChangesAsync();
            return count;
        }

        public void Validate(ProductIngestionDto dto)
        // ????
        {
            if (string.IsNullOrWhiteSpace(dto.ProductId))
                throw new ArgumentException("ProductId is required.");
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Name is required.");
            if (string.IsNullOrWhiteSpace(dto.Brand))
                throw new ArgumentException("Brand is required.");
            if (string.IsNullOrWhiteSpace(dto.Category))
                throw new ArgumentException("Category is required.");
            if (string.IsNullOrWhiteSpace(dto.SkuId))
                throw new ArgumentException("SkuId is required.");
            if (string.IsNullOrWhiteSpace(dto.ListPrice))
                throw new ArgumentException("ListPrice is required.");
            if (string.IsNullOrWhiteSpace(dto.Date))
                throw new ArgumentException("Date is required.");
        }
    }
}

