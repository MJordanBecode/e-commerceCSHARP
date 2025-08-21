using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid(); // Ajout de l'Id manquant

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        [Required, MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required, MaxLength(1000)]
        public string Ingredients { get; set; } = string.Empty;

        [Required, MaxLength(1000)]
        public string PracticalInfo { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Brand { get; set; } = string.Empty;

        public decimal ProductPrice { get; set; }

        public decimal PricePerKilo { get; set; }

        public int StockQuantity { get; set; } = 0;

        public List<Favoris> FavorisList { get; set; } = new List<Favoris>();

        public List<StockMovement> StockMovements { get; set; } = new List<StockMovement>();

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}