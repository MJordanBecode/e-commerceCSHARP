using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class StockMovement
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    public int QuantityChanged { get; set; }

    [Required, MaxLength(50)]
    public string MovementType { get; set; }  // "IN" / "OUT"

    public DateTime MovementDate { get; set; } = DateTime.Now;
}