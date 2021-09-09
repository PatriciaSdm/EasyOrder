using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Models;
using EasyOrder.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Repository
{
    public class ExtraRepository : Repository<Extra>, IExtraRepository
    {
        public ExtraRepository(EasyOrderContext context) : base(context)
        {
        }
    }
}
