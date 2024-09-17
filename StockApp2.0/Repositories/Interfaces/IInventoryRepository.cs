using Models.Models;

namespace StockApp2._0.Repositories.Interfaces;

public interface IInventoryRepository
{
    Task<Inventory> CreateInventoryAsync(Inventory inventory);
    Task<IEnumerable<Inventory>> GetAllInventoriesAsync(int skip, int take);
    Task<double> GetTotalAvailableQuantityByInventoryIdAndProductIdAsync(int productId, int inventoryId);
}
