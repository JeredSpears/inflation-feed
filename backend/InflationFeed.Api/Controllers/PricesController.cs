using Microsoft.AspNetCore.Mvc;
using InflationFeed.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace InflationFeed.Api.Controllers
{
    // ai template to just get something working
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PricesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prices = await _context.Prices.ToListAsync();
            return Ok(prices);
        }
    }
}