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
    public class ProductCommentConfiguration :IEntityTypeConfiguration<ProductCommentEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCommentEntity> builder)
        {
            builder.ToTable("ProductComments");

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

            //UserId
            builder.Property(p => p.UserId)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            //Text
            builder.Property(p => p.Text)
               .IsRequired()
               .HasMaxLength(500);

            //StarCount
            builder.Property(p => p.StarCount)
               .IsRequired()
               .HasMaxLength(5);

            // IsConfirmed
            builder.Property(p => p.IsConfirmed)
                .IsRequired()
                .HasDefaultValue(false);   


            // CreatedAt
            builder.Property(p => p.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
