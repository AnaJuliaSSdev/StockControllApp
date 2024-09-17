using System.ComponentModel.DataAnnotations;

namespace Models.DTO.InventoryDto;

public class CreateInventoryDto
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;
}
