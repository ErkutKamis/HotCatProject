using HC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Interface
{
    public interface IBaseEntity // BaseEntity abstract bir sınıf olmalı ancak kullanıcı sınıflarında birden fazla sınıftan miras alacağımız için interface olarak aldık...
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }
    }
}
