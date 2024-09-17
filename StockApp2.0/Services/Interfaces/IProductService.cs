using Models.DTO.Product;

namespace StockApp2._0.Services.Interfaces;

public interface IProductService
{
    Task<ListProductDto> CreateProductAsync(CreateProductDto productDto);
    Task<IEnumerable<ListProductDto>> GetAllProductsAsync(int skip, int take);

}
