using App.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace App.Data.Context
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
        public DbSet<ProductEntity> Products => Set<ProductEntity>();

        public DbSet<ProductCommentEntity> ProductComments => Set<ProductCommentEntity>();
        public DbSet<ProductImageEntity> ProductImages => Set<ProductImageEntity>();
        public DbSet<CartItemEntity> CartItems => Set<CartItemEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganikBahceDbContext).Assembly);
        }

    }
}
