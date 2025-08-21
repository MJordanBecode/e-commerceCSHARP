using backend.Models;              // Pour accéder à Product, Category, etc.
using Microsoft.EntityFrameworkCore; // Si tu utilises EF Core (DbContext)
using Microsoft.Extensions.DependencyInjection; // Pour CreateScope()
using Bogus;                       // Pour générer des données factices

namespace backend.Data;

public class ProductSeed
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Ici tu génères tes fausses données avec Bogus
    }
}