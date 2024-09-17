using Models.DTO.InventoryDto;
using Models.Models;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;

    public InventoryService(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<ListInventoryDto> CreateInventoryAsync(CreateInventoryDto createInventoryDto)
    {
        Inventory inventory = Mapper.Mapper.Map<Inventory>(createInventoryDto);
        await _inventoryRepository.CreateInventoryAsync(inventory);
        return Mapper.Mapper.Map<ListInventoryDto>(inventory);
    }

    public async Task<IEnumerable<ListInventoryDto>> GetAllInventoriesAsync(int skip, int take)
    {
        IEnumerable<Inventory> inventories = await _inventoryRepository.GetAllInventoriesAsync(skip, take);
        List<ListInventoryDto> inventoriesDto = [];
        inventoriesDto.AddRange(from Inventory inventory in inventories
                                select Mapper.Mapper.Map<ListInventoryDto>(inventory));
        return inventoriesDto;
    }

    public async Task<double> GetTotalQuantityByInventoryIdAndProductIdAsync(int inventoryId, int productId)
    {
        return await _inventoryRepository.GetTotalAvailableQuantityByInventoryIdAndProductIdAsync(productId, inventoryId);
    }
}
