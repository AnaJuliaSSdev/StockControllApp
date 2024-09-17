using Models.DTO.CategoryDto;

namespace StockApp2._0.Services.Interfaces;

public interface ICategoryService
{
    Task<ListCategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task<IEnumerable<ListCategoryDto>> GetAllCategoriesAsync(int skip, int take);
}
