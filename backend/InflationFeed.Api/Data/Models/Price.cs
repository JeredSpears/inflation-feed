
namespace InflationFeed.Api.Data.Models
{
    public class Price
    {
        public int Id { get; set; }
        public string? Sku { get; set; }
        public string? Store { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}