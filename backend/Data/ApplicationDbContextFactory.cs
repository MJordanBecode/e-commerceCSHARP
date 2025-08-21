// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
//
// namespace backend.Data;
//
// public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
// {
//     public ApplicationDbContext CreateDbContext(string[] args)
//     {
//         // On récupère la configuration depuis appsettings.json
//         var configuration = new ConfigurationBuilder()
//             .SetBasePath(Directory.GetCurrentDirectory())
//             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//             .Build();
//
//         var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//
//         // Utilisation de PostgreSQL via Npgsql
//         var connectionString = configuration.GetConnectionString("DefaultConnection");
//         optionsBuilder.UseNpgsql(connectionString);
//
//         return new ApplicationDbContext(optionsBuilder.Options);
//     }
// }