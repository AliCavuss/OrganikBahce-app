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
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder) 
        {
            builder.ToTable("Orders");

            // Primary Key
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            //UserId
            builder.Property(o => o.UserId)
                .IsRequired();

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            // OrderCode
            builder.Property(o => o.OrderCode)
                .IsRequired()
                .HasMaxLength(2);

            // Address
            builder.Property(o => o.Address)
                .IsRequired()
                .HasMaxLength(250);


            //CreatedAt
            builder.Property(o => o.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");


        }
   
    }
}
