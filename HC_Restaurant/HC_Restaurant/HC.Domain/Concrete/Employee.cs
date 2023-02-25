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
    public class Employee : BaseEntity , IBaseEntity
    {
        public Employee()
        {
            Status = Status.Active;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public Guid DepartmentID { get; set; }

        //Relations
        public virtual Department Department { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
