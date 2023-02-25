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
    public class EmployeeSeed : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
               new Employee { ID = Guid.NewGuid(), FirstName = "Bahadır", LastName = "Arda", Title = "Mr.", Status = Status.Active , DepartmentID = Guid.Parse("1D42e49b-9c8d-4d44-a508-eb12a50c28d8") },
               new Employee { ID = Guid.NewGuid(), FirstName = "Erkut", LastName = "Kamış", Title = "Mr.", Status = Status.Active , DepartmentID = Guid.Parse("2D42e49b-9c8d-4d44-a508-eb12a50c28d8") },
               new Employee { ID = Guid.NewGuid(), FirstName = "Çağrı", LastName = "Yolyapar", Title = "Mr.", Status = Status.Active , DepartmentID = Guid.Parse("3D42e49b-9c8d-4d44-a508-eb12a50c28d8") },
               new Employee { ID = Guid.NewGuid(), FirstName = "Fatih", LastName = "Günalp", Title = "Mr.", Status = Status.Active , DepartmentID = Guid.Parse("4D42e49b-9c8d-4d44-a508-eb12a50c28d8") }
               );
        }
    }
}
