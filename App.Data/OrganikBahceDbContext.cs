using App.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace App.Data
{
    public class OrganikBahceDbContext : DbContext
    {
        public OrganikBahceDbContext(DbContextOptions<OrganikBahceDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<RoleEntity> Roles => Set<RoleEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganikBahceDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            var seedTime = new DateTime(2026, 02, 16, 12, 0, 0, DateTimeKind.Utc);

            // 1) 3 adet rol
            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = 1, Name = "seller", CreatedAt = seedTime },
                new RoleEntity { Id = 2, Name = "buyer", CreatedAt = seedTime },
                new RoleEntity { Id = 3, Name = "admin", CreatedAt = seedTime }
            );

            // 2) 1 adet admin user
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = 1,
                    Email = "admin@organikbahce.com",
                    FirstName = "Admin",
                    LastName = "User",
                    Password = "Admin123!", 
                    RoleId = 3,
                    Enabled = true,
                    CreatedAt = seedTime
                }
            );

            // 3) 10 adet kategori
            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { Id = 1, Name = "Sebze", Color = "28a745", IconCssClass = "fa-solid fa-carrot", CreatedAt = seedTime },
                new CategoryEntity { Id = 2, Name = "Meyve", Color = "dc3545", IconCssClass = "fa-solid fa-apple-whole", CreatedAt = seedTime },
                new CategoryEntity { Id = 3, Name = "Süt & Süt Ü.", Color = "0dcaf0", IconCssClass = "fa-solid fa-cow", CreatedAt = seedTime },
                new CategoryEntity { Id = 4, Name = "Et & Tavuk", Color = "fd7e14", IconCssClass = "fa-solid fa-drumstick-bite", CreatedAt = seedTime },
                new CategoryEntity { Id = 5, Name = "Bakliyat", Color = "6f42c1", IconCssClass = "fa-solid fa-seedling", CreatedAt = seedTime },
                new CategoryEntity { Id = 6, Name = "Kahvaltılık", Color = "ffc107", IconCssClass = "fa-solid fa-egg", CreatedAt = seedTime },
                new CategoryEntity { Id = 7, Name = "İçecek", Color = "198754", IconCssClass = "fa-solid fa-mug-hot", CreatedAt = seedTime },
                new CategoryEntity { Id = 8, Name = "Atıştırmalık", Color = "20c997", IconCssClass = "fa-solid fa-cookie-bite", CreatedAt = seedTime },
                new CategoryEntity { Id = 9, Name = "Temel Gıda", Color = "0d6efd", IconCssClass = "fa-solid fa-bread-slice", CreatedAt = seedTime },
                new CategoryEntity { Id = 10, Name = "Baharat", Color = "adb5bd", IconCssClass = "fa-solid fa-pepper-hot", CreatedAt = seedTime }
            );
        }
    }
}
