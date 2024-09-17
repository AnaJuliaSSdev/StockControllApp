using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models.Models;

public class Batch
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [AllowNull]
    public DateTime? ExpiryDate { get; set; }

    [AllowNull]
    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be positive.")]
    public double? Price { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
    [Range(0, double.MaxValue, ErrorMessage = "Quantity must be positive.")]
    public double Quantity { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public ETypeBatch TypeBatch { get; set; }

    [Required]
    public int InventoryId { get; set; }

    public virtual Product Product { get; set; }
    public virtual Inventory Inventory { get; set; }
}
