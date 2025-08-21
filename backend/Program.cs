using backend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using backend.Models;
using backend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); // si tu as ton extension AddOpenApi()

// Exemple pour DbContext et Identity (à décommenter si nécessaire)

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));//databaseConnection

builder.Services.AddIdentity<ApplicationUser, IdentityRole>() //Si j'utilise identity et que je change le IdentityUsser, je crée un nouveau fichier "ApplicationUser" avec les nouvelles propriétés que je dois mettre pour utilisateur, donc je dois changer IdentityUser par ApplicationUser
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();




var app = builder.Build();

// 🔹 Seed la base au démarrage
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
