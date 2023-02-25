using HC.Domain.Abstract;
using HC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Concrete
{
    public class OrderDetail : BaseEntity , IBaseEntity
    {
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }

        // Relational Properties

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
