using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Context
{
    public interface IEntityTypeSeed<T>where T : class
    {
        void SeedData(EntityTypeBuilder<T> builder);
    }
}
