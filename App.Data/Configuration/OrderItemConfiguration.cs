using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.ToTable("OrderItems");

            // Primary Key
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            // OrderId (FK)
            builder.Property(o => o.OrderId)
                   .IsRequired();

            builder.HasOne(o => o.Order)
                   .WithMany()
                   .HasForeignKey(o => o.OrderId)
                   .OnDelete(DeleteBehavior.Cascade); 

            // ProductId (FK)
            builder.Property(o => o.ProductId)
                   .IsRequired();

            builder.HasOne(o => o.Product)
                   .WithMany()
                   .HasForeignKey(o => o.ProductId)
                   .OnDelete(DeleteBehavior.Restrict); 

            // Quantity
            builder.Property(o => o.Quantity)
                   .IsRequired(); 

            // UnitPrice
            builder.Property(o => o.UnitPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            // CreatedAt
            builder.Property(o => o.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
