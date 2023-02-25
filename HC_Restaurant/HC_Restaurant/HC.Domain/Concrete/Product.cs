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
    public class Product : BaseEntity , IBaseEntity
    {
        public Product()
        {
            Status = Status.Active;
        }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public short UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImagePath { get; set; }
        public Guid CategoryID { get; set; }

        // Relational Properties
        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
