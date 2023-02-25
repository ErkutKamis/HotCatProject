using HC.Domain.Concrete;
using HC.Domain.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Domain.Repositories.EntityTypeRepository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
}
