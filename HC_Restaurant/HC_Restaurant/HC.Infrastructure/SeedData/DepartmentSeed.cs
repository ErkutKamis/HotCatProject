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
    public class DepartmentSeed : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
               new Department { ID = Guid.Parse("1D42e49b-9c8d-4d44-a508-eb12a50c28d8"), DepartmentName = "General management", Status = Status.Active },
               new Department { ID = Guid.Parse("2D42e49b-9c8d-4d44-a508-eb12a50c28d8"), DepartmentName = "Purchase management", Status = Status.Active },
               new Department { ID = Guid.Parse("3D42e49b-9c8d-4d44-a508-eb12a50c28d8"), DepartmentName = "Personal management", Status = Status.Active },
               new Department { ID = Guid.Parse("4D42e49b-9c8d-4d44-a508-eb12a50c28d8"), DepartmentName = "Sales management", Status = Status.Active }
               );
        }
    }
}
