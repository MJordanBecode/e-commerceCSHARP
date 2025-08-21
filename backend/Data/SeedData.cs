using backend.Models;              // Pour accéder à Product, Category, etc.
using Microsoft.EntityFrameworkCore; // Si tu utilises EF Core (DbContext)
using Microsoft.Extensions.DependencyInjection; // Pour CreateScope()
using Bogus;                       // Pour générer des données factices

namespace backend.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

 //Meetre toutes les seed ici 
 
 // CategorySeed.Seed(context); //Exemple 
    }
}
