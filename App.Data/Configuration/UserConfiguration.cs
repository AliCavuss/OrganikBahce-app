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
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            // Primary Key
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            // Email
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(u => u.Email)
                   .IsUnique();

            // FirstName
            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            // LastName
            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            // Password
            builder.Property(u => u.Password)
                   .IsRequired();

            // RoleId (FK)
            builder.Property(u => u.RoleId)
                   .IsRequired();

            builder.HasOne(u => u.Role)
                   .WithMany()
                   .HasForeignKey(u => u.RoleId);

            // Enabled
            builder.Property(u => u.Enabled)
                   .IsRequired()
                   .HasDefaultValue(true);

            // CreatedAt
            builder.Property(u => u.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");
        }
    }

}   