﻿using HC.Domain.Concrete;
using HC.Domain.Repositories.EntityTypeRepository;
using HC.Infrastructure.Context;
using HC.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Infrastructure.Repositories.Concrete
{
    public class DepartmentRepository : BaseRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(HC_DbContext db) : base(db)
        {

        }

 
    }
}
