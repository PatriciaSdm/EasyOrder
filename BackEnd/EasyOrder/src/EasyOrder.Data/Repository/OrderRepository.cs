using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Models;
using EasyOrder.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EasyOrderContext context) : base(context)
        {
        }
    }
}
