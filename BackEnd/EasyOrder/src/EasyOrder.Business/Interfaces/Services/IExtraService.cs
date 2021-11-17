using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces.Services
{
    public interface IExtraService : IDisposable
    {
        Task<Extra> GetWithCategories(Guid id);
        Task<IEnumerable<Extra>> GetWithCategories();
        Task<List<Extra>> GetAll();
        Task<Extra> GetById(Guid id);
        Task<bool> Include(Extra extra);
        Task<bool> Update(Extra extra);
        
    }
}
