using HC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hc.Application.Models.VM
{
    public class EmployeeVM
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public string Department { get; set; }
        public Guid? DepartmentID { get; set; }

        public Status Status { get; set; }
    }
}
