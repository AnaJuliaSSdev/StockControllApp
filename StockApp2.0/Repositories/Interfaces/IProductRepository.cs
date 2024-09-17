using Models.Models;

namespace StockApp2._0.Repositories.Interfaces;

public interface IProductRepository
{
    Task<Product> CreateProductAsync(Product product);
    Task<Product?> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllProductsAsync(int skip, int take);
}
