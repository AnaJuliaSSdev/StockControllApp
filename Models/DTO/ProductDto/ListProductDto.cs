using Models.Models;

namespace Models.DTO.Product;

public class ListProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Perishable { get; set; } = false;
    public Category Category { get; set; }
}
