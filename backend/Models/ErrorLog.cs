using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class ErrorLog
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string ErrorMessage { get; set; }

    public string StackTrace { get; set; }

    public DateTime LoggedAt { get; set; } = DateTime.Now;
}