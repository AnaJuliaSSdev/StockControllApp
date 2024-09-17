using System.ComponentModel.DataAnnotations;

namespace Models.DTO.Product;

public class CreateProductDto
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Perishable is required.")]
    public bool Perishable { get; set; } = false;

    [Required(ErrorMessage = "Category is required.")]
    public int CategoryId { get; set; }
}
