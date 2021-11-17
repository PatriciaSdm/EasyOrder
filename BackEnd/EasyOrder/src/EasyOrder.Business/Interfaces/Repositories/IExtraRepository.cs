using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces.Repositories
{
    public interface IExtraRepository : IRepository<Extra>
    {
        Task<IEnumerable<Extra>> GetWithCategories();

        Task<Extra> GetWithCategories(Guid id);
    }
}
