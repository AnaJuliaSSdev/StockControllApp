using Models.DTO.BatchDto;

namespace StockApp2._0.Services.Interfaces;

public interface IBatchService
{
    Task<ListBatchDto> CreateBatchAsync(CreateBatchDto createBatchDto);
    Task<IEnumerable<ListBatchDto>> GetAllBatchesAsync(int skip, int take);
}
