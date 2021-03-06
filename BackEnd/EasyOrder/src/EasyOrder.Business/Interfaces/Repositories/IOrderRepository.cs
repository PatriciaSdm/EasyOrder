using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetWithItens(Guid id);
        Task<IEnumerable<Order>> GetWithItens();
    }
}
