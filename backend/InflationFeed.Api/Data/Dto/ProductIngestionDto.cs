using System.Text.Json.Serialization;

namespace InflationFeed.Api.Data.Dto
{
    public class ProductIngestionDto
    {
        [JsonPropertyName("productId")]
        public required string ProductId { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("brand")]
        public required string Brand { get; set; }
        [JsonPropertyName("category")]
        public required string Category { get; set; }
        [JsonPropertyName("skuId")]
        public required string SkuId { get; set; }
        [JsonPropertyName("listPrice")]
        public required string ListPrice { get; set; }
        [JsonPropertyName("salePrice")]
        public string? SalePrice { get; set; }
        [JsonPropertyName("unitListPrice")]
        public string? UnitListPrice { get; set; }
        [JsonPropertyName("unit")]
        public string? Unit { get; set; }
        [JsonPropertyName("isOnSale")]
        public bool IsOnSale { get; set; }
        [JsonPropertyName("date")]
        public required string Date { get; set; }
    }

}