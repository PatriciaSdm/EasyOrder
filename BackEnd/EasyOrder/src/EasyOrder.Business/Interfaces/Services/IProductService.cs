using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces.Services
{
    public interface IProductService : IDisposable
    {
        Task<Product> GetWithCategory(Guid id);
        Task<List<Product>> GetWithCategory();
        Task<bool> Include(Product product);
        Task<IEnumerable<Product>> GetByCategoryId(Guid id);
        Task<List<Product>> GetAll();
        Task<bool> Update(Product product);
        Task<Product> GetById(Guid id);
    }
}
