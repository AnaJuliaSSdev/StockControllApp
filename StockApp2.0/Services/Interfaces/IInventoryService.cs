using Models.DTO.InventoryDto;

namespace StockApp2._0.Services.Interfaces;

public interface IInventoryService
{
    Task<ListInventoryDto> CreateInventoryAsync(CreateInventoryDto createInventoryDto);
    Task<IEnumerable<ListInventoryDto>> GetAllInventoriesAsync(int skip, int take);
    Task<double> GetTotalQuantityByInventoryIdAndProductIdAsync(int inventoryId, int productId);
}
