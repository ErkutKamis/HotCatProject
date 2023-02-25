using HC.Domain.Enums;
using HC.Domain.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Concrete
{
    public class AppUserRole : IdentityRole , IBaseEntity
    {
        public AppUserRole()
        {
            Status = Status.Active;
        }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
