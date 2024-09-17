using Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models.DTO.BatchDto;

public class CreateBatchDto
{
    [AllowNull]
    public DateTime? ExpiryDate { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price must be positive.")]
    [AllowNull]
    public double? Price { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Quantity must be positive.")]
    public double Quantity { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int InventoryId { get; set; }

    [Required]
    public ETypeBatch TypeBatch { get; set; }
}
