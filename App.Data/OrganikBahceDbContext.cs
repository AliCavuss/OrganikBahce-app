using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    internal class OrganikBahceDbContext: DbContext
    {
        public OrganikBahceDbContext()
        {
            
        }


       //SQL'de işlenecek 

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<ProductEntity>().Property("Enabled")
        //        .HasDefaultValueSql("1");
        //}
    }
}
