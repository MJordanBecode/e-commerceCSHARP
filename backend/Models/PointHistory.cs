using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class PointHistory
    {
        [Key]
        public int Id { get; set; }  // SERIAL

        [Required]
        public Guid MemberCardId { get; set; } // FK
        public MemberCard MemberCard { get; set; } // Navigation

        [Required]
        public int PointsChanged { get; set; }

        [MaxLength(255)]
        public string ChangeReason { get; set; }

        public DateTime ChangeDate { get; set; } = DateTime.Now;
        
        

    }

}