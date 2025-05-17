public class Product
{
    public int Id { get; set; }
    public required int ProductId { get; set; }
    public required string Name { get; set; }
    public required string Brand { get; set; }
    public required string Category { get; set; }
    public required string SkuId { get; set; }
    public required decimal ListPrice { get; set; }
    public decimal? SalePrice { get; set; }
    public decimal? UnitListPrice { get; set; }
    public string? Unit { get; set; }
    public bool IsOnSale { get; set; }
    public DateTime Date { get; set; }
}