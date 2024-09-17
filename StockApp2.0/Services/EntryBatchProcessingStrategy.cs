using Models.DTO.BatchDto;
using Models.Models;
using StockApp2._0.Exceptions;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Services;

public class EntryBatchProcessingStrategy: IBatchProcessingStrategy
{
    private readonly IProductRepository _productRepository;

    public EntryBatchProcessingStrategy(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task ProcessBatchAsync(CreateBatchDto createBatchDto)
    {
        if (await IsProductPerishable(createBatchDto.ProductId))
        {
            if (!createBatchDto.ExpiryDate.HasValue)
                throw new InvalidBatchException("Perishable products must have an expiry date.");

            if (createBatchDto.ExpiryDate <= DateTime.UtcNow)
                throw new InvalidBatchException("It is not possible to add a batch with an expired expiration date.");
        }
    }

    private async Task<bool> IsProductPerishable(int productId)
    {
        Product? product = await _productRepository.GetProductByIdAsync(productId);
        return product == null ? throw new InvalidBatchException("Product not found") : product.Perishable;
    }
}
