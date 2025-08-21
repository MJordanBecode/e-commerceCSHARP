using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class OrderItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserCommandId { get; set; }
    public UserCommand UserCommand { get; set; }

    [Required]
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    public decimal PriceAtPurchase { get; set; }

    [Required]
    public int Quantity { get; set; }
}