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
    public class CategoryConfiguration :IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Categories");

            // Primary Key
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            // Name
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Color
            builder.Property(c => c.Color)
                .IsRequired()
                .HasMaxLength(6);

            // IconCssClass
            builder.Property(c => c.IconCssClass)
                .IsRequired()
                .HasMaxLength(50);

            //CreatedAt
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
