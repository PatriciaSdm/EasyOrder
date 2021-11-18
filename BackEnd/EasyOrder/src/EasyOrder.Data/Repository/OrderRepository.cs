using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Models;
using EasyOrder.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EasyOrderContext context) : base(context)
        {
   
        }

        public async Task<Order> GetWithItens(Guid id)
        {
            return await Db.Orders
                .Include(x => x.Items)
                    .ThenInclude(x => x.ItemExtras)
                        .ThenInclude(x => x.Item)
                .Include(x => x.Items)
                    .ThenInclude(x => x.ItemExtras)
                        .ThenInclude(x => x.Extra)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Order>> GetWithItens()
        {
            return await Db.Orders
                .Include(x => x.Items)
                    .ThenInclude(x => x.ItemExtras)
                        .ThenInclude(x => x.Item)
                .Include(x => x.Items)
                    .ThenInclude(x => x.ItemExtras)
                        .ThenInclude(x => x.Extra)
                .ToListAsync();
        }
    }
}
