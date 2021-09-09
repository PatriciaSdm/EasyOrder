using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Models;
using EasyOrder.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(EasyOrderContext context) : base(context)
        {
        }
    }
}
