using InflationFeed.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace InflationFeed.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngestionController(ProductIngestionService service) : ControllerBase
    {
        private readonly ProductIngestionService _service = service;

        [HttpPost]
        [Route("file")]
        public async Task<IActionResult> UploadJsonFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var stream = new StreamReader(file.OpenReadStream());
            var json = await stream.ReadToEndAsync();

            try
            {
                var count = await _service.IngestAsync(json);
                return Ok(new { Count = count });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while processing the file.");
            }
        }
    }

}

