using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public override string Email { get; set; } = string.Empty;

        [Phone]
        public override string? PhoneNumber { get; set; } = string.Empty; // Ajout du ?

        [Required, MaxLength(255)]
        public string Address { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string State { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        // 🔹 Relations - Ajout du ? pour nullable
        public MemberCard? MemberCard { get; set; }
        public List<Favoris> Favoris { get; set; } = new List<Favoris>();
        public List<UserCommand> UserCommands { get; set; } = new List<UserCommand>();
        public List<Notification> Notifications { get; set; } = new List<Notification>();
        
    }
}