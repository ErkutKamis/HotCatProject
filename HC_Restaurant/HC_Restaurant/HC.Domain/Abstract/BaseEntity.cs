using HC.Domain.Enums;
using HC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Abstract
{
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Status = Status.Active;
            CreatedDate = DateTime.Now;
        }

        public Guid ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }
    }
}
