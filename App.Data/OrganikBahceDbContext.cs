using App.Data.Configuration;
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




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganikBahceDbContext).Assembly);
        }
    }
}
