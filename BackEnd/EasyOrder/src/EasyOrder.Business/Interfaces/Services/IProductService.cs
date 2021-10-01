using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces.Services
{
    public interface IProductService : IDisposable
    {
        Task<bool> Include(Product product);
        Task<IEnumerable<Product>> GetByCategoryId(Guid id);
        Task<List<Product>> GetAll();
    }
}
