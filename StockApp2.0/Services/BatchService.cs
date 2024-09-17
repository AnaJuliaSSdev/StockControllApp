using Models.DTO.BatchDto;
using Models.Models;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Services;

public class BatchService : IBatchService
{
    private readonly IBatchRepository _batchRepository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IBatchFactory _batchFactory;
    private readonly IBatchProcessingStrategyFactory _batchProcessingStrategyFactory;

    public BatchService(IBatchRepository batchRepository, IInventoryRepository inventoryRepository, IBatchFactory batchFactory, IBatchProcessingStrategyFactory batchProcessingStrategyFactory)
    {
        _batchRepository = batchRepository;
        _inventoryRepository = inventoryRepository;
        _batchFactory = batchFactory;
        _batchProcessingStrategyFactory = batchProcessingStrategyFactory;
    }

    public async Task<ListBatchDto> CreateBatchAsync(CreateBatchDto createBatchDto)
    {
        Batch batch = _batchFactory.CreateBatch(createBatchDto);
        var strategy = _batchProcessingStrategyFactory.GetStrategy(createBatchDto.TypeBatch);
        await strategy.ProcessBatchAsync(createBatchDto);
        await _batchRepository.CreateBatchAsync(batch);

        return Mapper.Mapper.Map<ListBatchDto>(batch);
    }

    public async Task<IEnumerable<ListBatchDto>> GetAllBatchesAsync(int skip, int take)
    {
        IEnumerable<Batch> batches = await _batchRepository.GetAllBatchesAsync(skip, take);
        List<ListBatchDto> batchesDto =
        [
            .. from Batch batch in batches
                                select Mapper.Mapper.Map<ListBatchDto>(batch),
        ];

        return batchesDto;
    }
}
