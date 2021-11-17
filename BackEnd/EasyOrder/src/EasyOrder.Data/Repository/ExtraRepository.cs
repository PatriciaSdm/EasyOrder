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

        public virtual async Task Get(Extra entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        public async Task<Extra> GetWithCategories(Guid id)
        {
            return await Db.Extras
                .Include(x => x.CategoryExtras)
                .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Extra>> GetWithCategories()
        {
            return await Db.Extras
                .Include(x => x.CategoryExtras)
                .ThenInclude(x => x.Category)
                .ToListAsync();
        }
    }
}
