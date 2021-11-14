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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EasyOrderContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Product>> GetByIdCategory(Guid idCategory)
        {
            return await Db.Products.Where(x => x.IdCategory == idCategory).ToListAsync();
        }

        public virtual async Task UpdateAll(List<Product> entities)
        {
            DbSet.UpdateRange(entities);
            await SaveChanges();
        }
    }
}
