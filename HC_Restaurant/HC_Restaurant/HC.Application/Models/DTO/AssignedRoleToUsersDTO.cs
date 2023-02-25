using HC.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hc.Application.Models.DTO
{
    public class AssignedRoleToUsersDTO
    {
        public AppUserRole Role { get; set; }
        public IEnumerable<AppUser> HasRole { get; set; }
        public IEnumerable<AppUser> HasNoRole { get; set; }
        public string Name { get; set; }


        public string[] UsersToBeAdded { get; set; }
        public string[] UsersToBeDeleted { get; set; }
    }
}
