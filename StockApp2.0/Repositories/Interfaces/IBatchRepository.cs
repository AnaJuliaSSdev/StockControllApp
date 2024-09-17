using Models.Models;

namespace StockApp2._0.Repositories.Interfaces;

public interface IBatchRepository
{
    Task<Batch> CreateBatchAsync(Batch batch);
    Task<IEnumerable<Batch>> GetAllBatchesAsync(int skip, int take);
    Task<IEnumerable<Batch>> GetAllAvaliableBatchesByInventoryIdAndProductIdAsync(int productId, int inventoryId);
}
