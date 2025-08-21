using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models; 
public class Category
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(100)]
    public string CategoryName { get; set; }

    [Required]
    public string Name { get; set; }
    
    //Navigation : 1 catégorie => +ieurs produits
    public List<Product> Products { get; set; }
}