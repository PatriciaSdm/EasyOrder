using EasyOrder.Business.Interfaces.INotifications;
using EasyOrder.Business.Interfaces.Services;
using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Services
{
    public class OrderService : Service, IOrderService
    {
        public OrderService(INotifier notifier) : base(notifier)
        {

        }

        public async Task<bool> Close(Order order)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetByIdWithItens(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Include(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
