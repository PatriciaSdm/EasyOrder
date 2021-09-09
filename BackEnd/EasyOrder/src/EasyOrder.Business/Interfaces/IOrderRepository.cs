using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        
    }
}
