using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces.Services
{
    public interface IOrderService : IDisposable
    {
        Task<bool> Include(Order order);
        Task<bool> Update(Order order);
        Task<bool> Close(Order order);
        Task<Order> GetById(Guid id);
        Task<Order> GetByIdWithItens(Guid id);
        Task<List<Order>> GetAll();
    }
}
