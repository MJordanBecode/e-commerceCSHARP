using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<MemberCard> MemberCards { get; set; }
    public DbSet<PointHistory> PointHistories { get; set; }
    public DbSet<Favoris> Favoris { get; set; }
    public DbSet<Promo> Promos { get; set; }
    public DbSet<UserCommand> UserCommands { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<ErrorLog> ErrorLogs { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Configure Identity tables for ApplicationUser

        // Category
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
        });

        // Product
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(255);
            entity.Property(p => p.ProductPrice).HasColumnType("decimal(10,2)");
            entity.Property(p => p.PricePerKilo).HasColumnType("decimal(10,2)");
            entity.Property(p => p.Description).IsRequired().HasMaxLength(1000);
            entity.Property(p => p.Ingredients).IsRequired().HasMaxLength(1000);
            entity.Property(p => p.PracticalInfo).IsRequired().HasMaxLength(1000);
            entity.Property(p => p.Brand).IsRequired().HasMaxLength(100);
            entity.HasOne(p => p.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(p => p.CategoryId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // MemberCard
        modelBuilder.Entity<MemberCard>(entity =>
        {
            entity.HasKey(mc => mc.Id);
            entity.Property(mc => mc.Id).ValueGeneratedOnAdd();
            entity.HasOne(mc => mc.User)
                  .WithOne(u => u.MemberCard)
                  .HasForeignKey<MemberCard>(mc => mc.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.Property(mc => mc.TotalPoints).HasDefaultValue(0);
        });

        // PointHistory
        modelBuilder.Entity<PointHistory>(entity =>
        {
            entity.HasKey(ph => ph.Id);
            entity.HasOne(ph => ph.MemberCard)
                  .WithMany(mc => mc.PointHistories)
                  .HasForeignKey(ph => ph.MemberCardId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.Property(ph => ph.ChangeDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(ph => ph.ChangeReason).IsRequired().HasMaxLength(255);
        });

        // Favoris
        modelBuilder.Entity<Favoris>(entity =>
        {
            entity.HasKey(f => f.Id);
            entity.HasOne(f => f.User)
                  .WithMany(u => u.Favoris)
                  .HasForeignKey(f => f.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(f => f.Product)
                  .WithMany(p => p.FavorisList)
                  .HasForeignKey(f => f.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.Property(f => f.Liked).HasDefaultValue(true);
        });

        // Promo
        modelBuilder.Entity<Promo>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.GeneratedCode).IsRequired().HasMaxLength(15);
            entity.HasIndex(p => p.GeneratedCode).IsUnique();
            entity.Property(p => p.Percent).IsRequired();
        });

        // UserCommand
        modelBuilder.Entity<UserCommand>(entity =>
        {
            entity.HasKey(uc => uc.Id);
            entity.HasOne(uc => uc.User)
                  .WithMany(u => u.UserCommands)
                  .HasForeignKey(uc => uc.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.Property(uc => uc.OrderDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(uc => uc.TotalAmount).HasColumnType("decimal(10,2)").IsRequired();
        });

        // OrderItem
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(oi => oi.Id);
            entity.HasOne(oi => oi.UserCommand)
                  .WithMany(uc => uc.OrderItems)
                  .HasForeignKey(oi => oi.UserCommandId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(oi => oi.Product)
                  .WithMany(p => p.OrderItems)
                  .HasForeignKey(oi => oi.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.Property(oi => oi.PriceAtPurchase).HasColumnType("decimal(10,2)").IsRequired();
        });

        // Notification
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(n => n.Id);
            entity.HasOne(n => n.User)
                  .WithMany(u => u.Notifications)
                  .HasForeignKey(n => n.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.Property(n => n.IsRead).HasDefaultValue(false);
            entity.Property(n => n.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(n => n.Message).IsRequired().HasMaxLength(1000);
        });

        // ErrorLog
        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ErrorMessage).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.StackTrace).IsRequired().HasMaxLength(4000);
            entity.Property(e => e.LoggedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        // StockMovement
        modelBuilder.Entity<StockMovement>(entity =>
        {
            entity.HasKey(sm => sm.Id);
            entity.HasOne(sm => sm.Product)
                  .WithMany(p => p.StockMovements)
                  .HasForeignKey(sm => sm.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.Property(sm => sm.MovementType).IsRequired().HasMaxLength(50);
            entity.Property(sm => sm.MovementDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}
}