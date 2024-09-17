using Models.DTO.Product;
using Models.Models;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Services.Interfaces;

namespace StockApp2._0.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ListProductDto> CreateProductAsync(CreateProductDto productDto)
    {
        Product product = Mapper.Mapper.Map<Product>(productDto);

        await  _productRepository.CreateProductAsync(product);

        return  Mapper.Mapper.Map<ListProductDto>(product); 
    }

    public async Task<IEnumerable<ListProductDto>> GetAllProductsAsync(int skip, int take)
    {
        IEnumerable<Product> products = await _productRepository.GetAllProductsAsync(skip, take);
        List<ListProductDto> productsDto = [];
        productsDto.AddRange(from Product product in products
                             select Mapper.Mapper.Map<ListProductDto>(product));
        return productsDto;
    }
}
