using Models.Models;

namespace StockApp2._0.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<Category> CreateCategoryAsync(Category category);
    Task<IEnumerable<Category>> GetAllCategoriesAsync(int skip, int take);
}
