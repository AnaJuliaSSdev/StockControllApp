using Models.Models;

namespace Models.DTO.BatchDto;

public class ListBatchDto
{
    public int Id { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public double? Price { get; set; }
    public double Quantity { get; set; }
    public int ProductId { get; set; }
    public int InventoryId { get; set; }
    public ETypeBatch TypeBatch { get; set; }
}
