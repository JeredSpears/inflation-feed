
public class ProductIngestionDto
{
    public required string ProductId { get; set; }
    public required string Name { get; set; }
    public required string Brand { get; set; }
    public required string Category { get; set; }
    public required string SkuId { get; set; }
    public required string ListPrice { get; set; }
    public string? SalePrice { get; set; }
    public string? UnitListPrice { get; set; }
    public string? Unit { get; set; }
    public bool IsOnSale { get; set; }
    public required string Date { get; set; }
}