using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend.Models;

public class Favoris
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string UserId { get; set; }
    public required ApplicationUser User { get; set; }

    [Required]
    public Guid  ProductId { get; set; }
    public required Product Product { get; set; }

    public bool Liked { get; set; } = true;
}