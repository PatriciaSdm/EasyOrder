using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Models;
using EasyOrder.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Data.Repository
{
    public class ExtraRepository : Repository<Extra>, IExtraRepository
    {
        public ExtraRepository(EasyOrderContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Extra>> GetWithCategories(Guid id)
        {
            return await Db.Extras.Where(x => x.Id == id)
                .Include(x => x.Categories)
                .ToListAsync();
        }
    }
}
