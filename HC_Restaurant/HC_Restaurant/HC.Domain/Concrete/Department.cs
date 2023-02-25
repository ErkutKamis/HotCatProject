using HC.Domain.Abstract;
using HC.Domain.Enums;
using HC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Concrete
{
    public class Department : BaseEntity , IBaseEntity
    {
        public Department()
        {
            Status = Status.Active;
        }
        public string DepartmentName { get; set; }


        // Relational Properties

        public virtual List<Employee> Employees { get; set; }
    }
}
