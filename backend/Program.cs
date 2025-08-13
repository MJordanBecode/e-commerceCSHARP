var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();          // Pour activer les Controllers
builder.Services.AddEndpointsApiExplorer(); // Nécessaire pour OpenAPI/Swagger
builder.Services.AddOpenApi();              // Ton AddOpenApi existant
// Si tu utilises SignalR ou EF Core, tu peux les ajouter ici aussi
// builder.Services.AddSignalR();
// builder.Services.AddDbContext<YourDbContext>(...);

var app = builder.Build();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // Pour Swagger UI
    app.UseSwaggerUI();     // Interface test Swagger
    app.MapOpenApi();       // Pour Scalar ou autres clients OpenAPI
}

app.UseHttpsRedirection();

app.UseAuthorization(); // Si tu as des endpoints sécurisés

app.MapControllers(); // Mappe tous tes Controllers
// app.MapHub<NotificationHub>("/notificationHub"); // Si SignalR

app.Run();