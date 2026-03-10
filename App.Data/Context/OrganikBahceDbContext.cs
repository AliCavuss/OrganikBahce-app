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

       
    }
}
