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
    public class ProductImageConfiguration :IEntityTypeConfiguration<ProductImageEntity>
    {
        public void Configure(EntityTypeBuilder<ProductImageEntity> builder) 
        {
            builder.ToTable("ProductImages");

            // Primary Key
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            //ProductId
            builder.Property(p => p.ProductId)
                .IsRequired();

            builder.HasOne(p => p.Product)
                   .WithMany()
                   .HasForeignKey(p => p.ProductId);

            //Url
            builder.Property(p => p.Url)
                .IsRequired()
                .HasMaxLength(250);

            //CreatedAt
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
