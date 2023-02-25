using HC.Domain.Abstract;
using HC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Concrete
{
    public class Order : BaseEntity , IBaseEntity
    {
        public decimal TotalPrice { get; set; }

        // Sipariş işlemlerinin içerisindeki bilgilari daha rahat yakalamak adına açtıgımız property'lerden bir tanesi de TotalPrice'dir..

        public string UserName { get; set; }
        public string AppUserID { get; set; }
        public Guid EmployeeID { get; set; }

        // Relational Properties

        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
