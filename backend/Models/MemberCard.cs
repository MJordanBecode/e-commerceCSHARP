using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend.Models;

// ✅ MemberCard.cs
public class MemberCard
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string UserId { get; set; }  
    public ApplicationUser User { get; set; }  

    public int TotalPoints { get; set; } = 0;

    // ✅ Relation 1 (MemberCard) → plusieurs (PointHistory)
    public List<PointHistory> PointHistories { get; set; } = new();
}
