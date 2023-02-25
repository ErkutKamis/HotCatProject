﻿using HC.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hc.Application.Models.DTO
{
    public class CreateRoleDTO
    {
        public string Name { get; set; }

        public List<AppUser> AppUsers { get; set; }
    }
}
