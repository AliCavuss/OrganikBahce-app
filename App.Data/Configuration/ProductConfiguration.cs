using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Configuration
{
    public class ProductConfiguration: IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products");

            // Primary Key
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            //SellerId
            builder.Property(p => p.SellerId)
                   .IsRequired();

            builder.HasOne(p => p.Seller)
                   .WithMany()
                   .HasForeignKey(p => p.SellerId);

            //CategoryId
            builder.Property(p=>p.CategoryId)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            //Name
            builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);

            //Price
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            //Details
            builder.Property(p => p.Details)
                .HasMaxLength(1000);

            //StockAmount
            builder.Property(p => p.StockAmount)
                .IsRequired();

            //CreatedAt
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Enabled
            builder.Property(p => p.Enabled)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
