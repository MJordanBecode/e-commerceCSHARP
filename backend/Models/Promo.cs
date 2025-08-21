using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Promo
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(15)]
    public string GeneratedCode { get; set; }

    [Required]
    public int Percent { get; set; }

    public DateTime? ExpirationDate { get; set; }
}