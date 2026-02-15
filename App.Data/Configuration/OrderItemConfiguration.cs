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
    public class OrderItemConfiguration: IEntityTypeConfiguration<OrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {

            builder.ToTable("OrderItems");

            // Primary Key
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            //OrderId
            builder.Property(o => o.OrderId)
                .IsRequired();

            builder.HasOne(o => o.Order)
                .WithMany()
                .HasForeignKey(o => o.OrderId);


            //ProductId
            builder.Property(o => o.ProductId)
                .IsRequired();

            builder.HasOne(o => o.Product)
                .WithMany()
                .HasForeignKey(o => o.ProductId);

            // Quantity
            builder.Property(o => o.Quantity)
                .IsRequired()
                .HasMaxLength(1);

            // UnitPrice
            builder.Property(o => o.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            //CreatedAt
            builder.Property(o => o.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
