using System.ComponentModel.DataAnnotations;
using backend;
using Microsoft.AspNetCore.Identity;

namespace backend.Models;

public class UserCommand
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Required]
    public decimal TotalAmount { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}