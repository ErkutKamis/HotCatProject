using HC.Domain.Concrete;
using HC.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Infrastructure.SeedData
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
              new Category { ID = Guid.Parse("1C42e49b-9c8d-4d44-a508-eb12a50c28d8"), CategoryName = "East Asian", Description = "Asian food is good", Status = Status.Active  },
              new Category { ID = Guid.Parse("2C42e49b-9c8d-4d44-a508-eb12a50c28d8"), CategoryName = "Turkish", Description = "Turkish food is good", Status = Status.Active },
              new Category { ID = Guid.Parse("3C42e49b-9c8d-4d44-a508-eb12a50c28d8"), CategoryName = "Global", Description = "Global food is good", Status = Status.Active }
              );
        }
    }
}
