using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategory(Guid id);
        Task<List<Product>> GetWithCategory();
        Task<List<Product>> GetWithCategoryAndExtras();
        Task<IEnumerable<Product>> GetByIdCategory(Guid idCategory);
        Task UpdateAll(List<Product> entities);
    }
}
