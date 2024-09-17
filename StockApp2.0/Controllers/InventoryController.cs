using Microsoft.AspNetCore.Mvc;
using Models.DTO.InventoryDto;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateInventoryAsync([FromBody] CreateInventoryDto createInventoryDto)
    {
        ListInventoryDto listInventoryDto = await _inventoryService.CreateInventoryAsync(createInventoryDto);

        return Ok(listInventoryDto);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllInventoriesAsync([FromQuery] int skip = 0, int take = 10)
    {
        IEnumerable<ListInventoryDto> inventoriesDto = await _inventoryService.GetAllInventoriesAsync(skip, take);
        return Ok(inventoriesDto);
    }

    [HttpGet("{inventoryId}/products/{productId}/quantity")]
    public async Task<IActionResult> GetTotalQuantityByInventoryIdAndProductIdAsync(int inventoryId, int productId)
    {
        double totalQuantity = await _inventoryService.GetTotalQuantityByInventoryIdAndProductIdAsync(inventoryId, productId);
        return Ok(totalQuantity);
    }
}
