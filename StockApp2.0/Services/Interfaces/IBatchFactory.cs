using Models.DTO.BatchDto;
using Models.Models;

namespace StockApp2._0.Services.Interfaces;

public interface IBatchFactory
{
    Batch CreateBatch(CreateBatchDto createBatchDto);
}
