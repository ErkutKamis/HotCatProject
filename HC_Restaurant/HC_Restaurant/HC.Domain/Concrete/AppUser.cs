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
    public class AppUser : IdentityUser , IBaseEntity
    {
        public AppUser()
        {
            Status = Status.Active;
        }

        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Adress { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }

        // Relations

        public virtual List<Order> Orders { get; set; }
    }
}
