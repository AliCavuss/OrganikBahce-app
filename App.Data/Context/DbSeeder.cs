using App.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Contexts
{
    internal static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Random rnd = Random.Shared;

            modelBuilder.Entity<RoleEntity>().HasData(
               new RoleEntity() { Id = 1, Name = "admin", CreatedAt = DateTime.UtcNow },
               new RoleEntity() { Id = 2, Name = "seller", CreatedAt = DateTime.UtcNow },
               new RoleEntity() { Id = 3, Name = "buyer", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity() { Id = 1, FirstName = "admin", LastName = "admin", Email = "admin@organikbahce.com", Enabled = true, RoleId = 1, Password = "1234", CreatedAt = DateTime.UtcNow },
                new UserEntity() { Id = 2, FirstName = "seller", LastName = "seller", Email = "seller@organikbahce.com", Enabled = true, RoleId = 2, Password = "1234", CreatedAt = DateTime.UtcNow },
                new UserEntity() { Id = 3, FirstName = "buyer", LastName = "buyer", Email = "buyer@organikbahce.com", Enabled = true, RoleId = 3, Password = "1234", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<CategoryEntity>().HasData(
                new List<CategoryEntity>{
                    new() { Id = 1, Name = "Taze Et & Tavuk", Color = "Red", IconCssClass = string.Empty, CreatedAt = DateTime.UtcNow },
                    new() { Id = 2, Name = "Organik Sebze", Color = "Green", IconCssClass = string.Empty, CreatedAt = DateTime.UtcNow },
                    new() { Id = 3, Name = "Taze Organik Meyveler", Color = "Yellow", IconCssClass = string.Empty, CreatedAt = DateTime.UtcNow },
                    new() { Id = 4, Name = "Tereyağ", Color = "Yellow", IconCssClass = string.Empty, CreatedAt = DateTime.UtcNow },
                    new() { Id = 5, Name = "Yumurta", Color = "Brown", IconCssClass = string.Empty, CreatedAt = DateTime.Now },
                    new() { Id = 6, Name = "Süt & Süt Ürünleri", Color = "White", IconCssClass = string.Empty, CreatedAt = DateTime.UtcNow },
                    new() { Id = 7, Name = "Organik Reçel & Bal", Color = "Pink", IconCssClass = string.Empty, CreatedAt = DateTime.UtcNow },
                    new() { Id = 8, Name = "Avokado", Color = "Green", IconCssClass = string.Empty, CreatedAt = DateTime.UtcNow },
                    new() { Id = 9, Name = "Bakliyatlar", Color = "Brown", IconCssClass = string.Empty, CreatedAt = DateTime.UtcNow }
                }
            );

            
            modelBuilder.Entity<ProductEntity>().HasData(
                new List<ProductEntity>{
                    new() {
                        Id = 1,
                        Name = "Nohut",
                        CategoryId = 9,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Nohut",
                        StockAmount = 100,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 2,
                        Name = "Muz",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Anamur Muzu",
                        StockAmount = 50,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 3,
                        Name = "Bal",
                        CategoryId = 7,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Kestane Balı",
                        StockAmount = 20,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 4,
                        Name = "Kırımızı Et",
                        CategoryId = 1,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "KEçi Eti",
                        StockAmount = 50,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 5,
                        Name = "Yaban Mersini",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Tropikal Yaban Mersini",
                        StockAmount = 75,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 6,
                        Name = "Ananas",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Ananas",
                        StockAmount = 100,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 7,
                        Name = "Ahududu",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Ahududu",
                        StockAmount = 80,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 8,
                        Name = "Çilek",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Dağ Çileği",
                        StockAmount = 100,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 9,
                        Name = "Ejder Meryvesi",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Ejder Meryvesi",
                        StockAmount = 20,
                        CreatedAt = DateTime.UtcNow
                    },
                    new () {
                        Id = 10,
                        Name = "Manda Yağı",
                        CategoryId = 4,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Manda Yağı",
                        StockAmount = 100,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 11,
                        Name = "Bulgur",
                        CategoryId = 9,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Bulgur",
                        StockAmount = 100,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 12,
                        Name = "Yumurta",
                        CategoryId = 5,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Yumurta",
                        StockAmount = 100,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 13,
                        Name = "Brokoli",
                        CategoryId = 2,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Brokoli",
                        StockAmount = 100,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 14,
                        Name = "Kuşkonmaz",
                        CategoryId = 2,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Kuşkonmaz",
                        StockAmount = 100,
                        CreatedAt = DateTime.UtcNow
                    },
                    new() {
                        Id = 15,
                        Name = "Çilek Reçeli",
                        CategoryId = 7,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Çilek Reçeli",
                        StockAmount = 20,
                        CreatedAt = DateTime.UtcNow
                    }
            });

            modelBuilder.Entity<ProductImageEntity>().HasData(
                new List<ProductImageEntity>
                {
                    new() { Id = 1, ProductId = 1, Url = "/img/product/discount/pd-3.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 2, ProductId = 2, Url = "/img/product/discount/pd-4.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 3, ProductId = 3, Url = "/img/product/discount/pd-5.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 4, ProductId = 4, Url = "/img/product/product-1.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 5, ProductId = 5, Url = "/img/product/product-2.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 6, ProductId = 6, Url = "/img/product/product-3.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 7, ProductId = 7, Url = "/img/product/product-8.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 8, ProductId = 8, Url = "/img/product/product-4.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 9, ProductId = 9, Url = "/img/product/product-7.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 10, ProductId = 10, Url = "/img/product/product-9.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 11, ProductId = 11, Url = "/img/product/product-11.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 12, ProductId = 12, Url = "/img/product/product-12.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 13, ProductId = 13, Url = "/img/latest-product/lp-1.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 14, ProductId = 14, Url = "/img/product/details/product-details-2.jpg", CreatedAt = DateTime.UtcNow },
                    new() { Id = 15, ProductId = 15, Url = "/img/product/product-10.jpg", CreatedAt = DateTime.UtcNow }
                }
            );

        }
    }
}
