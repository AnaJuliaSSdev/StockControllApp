using System.ComponentModel.DataAnnotations;

namespace Models.DTO.CategoryDto;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
