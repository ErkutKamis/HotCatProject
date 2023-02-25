using HC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hc.Application.Models.VM
{
    public class ProductVM
    {
        public Guid ID { get; set; } //Normalde VM'lerde ID bilgisinin olması doğru değildir. Gerekirse her get işlemi için farklı vms yazılmalı ve bilgi gücü sağlanmalıdır. Ama burada deneyler yaptığım ve adım adım öğrendiğim için, onu şimdi tanımladım!
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryID { get; set; }
        public Status Status { get; set; }
    }
}
