using Models.DTO.BatchDto;
using Models.Models;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Services;

public class BatchFactory : IBatchFactory
{
    public Batch CreateBatch(CreateBatchDto createBatchDto)
    {
        return new Batch
        {
            InventoryId = createBatchDto.InventoryId,
            ProductId = createBatchDto.ProductId,
            Quantity = createBatchDto.Quantity,
            TypeBatch = createBatchDto.TypeBatch,
            Price = createBatchDto.TypeBatch == ETypeBatch.Exit ? null : createBatchDto.Price,
            ExpiryDate = createBatchDto.TypeBatch == ETypeBatch.Exit ? null : createBatchDto.ExpiryDate
        };
    }
}
