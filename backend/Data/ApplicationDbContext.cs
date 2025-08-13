using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DefaultNamespace
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tu pourras ajouter tes DbSet pour les autres entités de ton e-commerce
        // Exemple :
        // public DbSet<Product> Products { get; set; }
        // public DbSet<Order> Orders { get; set; }
    }
}