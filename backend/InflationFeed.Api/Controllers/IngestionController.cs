using Microsoft.AspNetCore.Mvc;

namespace InflationFeed.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngestionController : ControllerBase
{
    private readonly ProductIngestionService _service;

    public IngestionController(ProductIngestionService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("json")]
    public async Task<IActionResult> Upload([FromBody] ProductIngestionDto dto)
    {
        // todo: validation method? also authorization/authentication?
        if (dto == null)
            return BadRequest();

        await _service.IngestAsync(dto);
        return Ok();
    }

    // uhhhhhh
    [HttpPost]
    [Route("file")]
    public async Task<IActionResult> UploadJsonFile([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        using var stream = new StreamReader(file.OpenReadStream());
        var json = await stream.ReadToEndAsync();

        ProductIngestionDto? dto;
        try
        {
            dto = System.Text.Json.JsonSerializer.Deserialize<ProductIngestionDto>(json);
        }
        catch
        {
            return BadRequest("Invalid JSON format.");
        }

        if (dto == null)
            return BadRequest("Could not parse JSON.");

        await _service.IngestAsync(dto);
        return Ok();
    }
}