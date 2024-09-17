using Microsoft.AspNetCore.Mvc;
using Models.DTO.BatchDto;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BatchController : ControllerBase
{
    private readonly IBatchService _batchService;

    public BatchController(IBatchService batchService)
    {
        _batchService = batchService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBatchAsync([FromBody] CreateBatchDto createBatchDto)
    {
        ListBatchDto listBatchDto = await _batchService.CreateBatchAsync(createBatchDto);

        return Ok(listBatchDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBatchesAsync([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        IEnumerable<ListBatchDto> batches = await _batchService.GetAllBatchesAsync(skip, take);
        return Ok(batches);
    }
}
