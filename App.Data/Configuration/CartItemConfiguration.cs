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
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItemEntity>
    {
        public void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {
            builder.ToTable("CartItems");

            // Primary Key
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            //UserId
            builder.Property(c => c.UserId)
                .IsRequired();

            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            //ProductId
            builder.Property(c => c.ProductId)
                   .IsRequired();

            builder.HasOne(c => c.Product)
                   .WithMany()
                   .HasForeignKey(c => c.ProductId);

            // Quantity
            builder.Property(c => c.Quantity)
                .IsRequired()
                .HasMaxLength(1);


            //CreatedAt
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

        }

     }
  
}
