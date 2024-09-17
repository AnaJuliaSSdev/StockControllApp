using Models.DTO.BatchDto;

namespace StockApp2._0.Services.Interfaces;

public interface IBatchProcessingStrategy
{
    Task ProcessBatchAsync(CreateBatchDto createBatchDto);
}
