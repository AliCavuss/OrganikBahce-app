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
    public class RoleConfiguration :IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Roles");

            // Primary Key
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            // Name
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(10);

            //CreatedAt
            builder.Property(r=>r.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
