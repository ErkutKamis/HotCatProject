using HC.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Service.Interface
{
    public interface IOrderDetailService
    {
        public Task<string> Create(OrderDetail model);
    }
}
