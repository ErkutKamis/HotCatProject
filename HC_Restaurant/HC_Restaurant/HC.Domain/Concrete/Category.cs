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
    public class Category : BaseEntity , IBaseEntity
    {
        public Category()
        {
            Status = Status.Active;
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }


        // Relational Properties
        public virtual List<Product> Products { get; set; }
       
    }
}
