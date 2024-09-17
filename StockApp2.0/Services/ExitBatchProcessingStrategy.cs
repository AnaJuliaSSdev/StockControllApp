using Models.DTO.BatchDto;
using StockApp2._0.Exceptions;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Services;

public class ExitBatchProcessingStrategy : IBatchProcessingStrategy
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IBatchRepository _batchRepository;

    public ExitBatchProcessingStrategy(IInventoryRepository inventoryRepository, IBatchRepository batchRepository)
    {
        _inventoryRepository = inventoryRepository;
        _batchRepository = batchRepository;
    }

    public async Task ProcessBatchAsync(CreateBatchDto createBatchDto)
    {
        double totalQuantity = await _inventoryRepository
            .GetTotalAvailableQuantityByInventoryIdAndProductIdAsync(createBatchDto.ProductId, createBatchDto.InventoryId);

        if (totalQuantity < createBatchDto.Quantity)
            throw new InsufficientProductQuantityException();
    }
}
