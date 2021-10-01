using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces.Services
{
    public interface IExtraService : IDisposable
    {
        Task<bool> Include(Extra extra);
        Task<IEnumerable<Extra>> GetExtraWithCategories(Guid id);
        Task<List<Extra>> GetAll();
        Task<bool> Update(Extra extra);
        Task<Extra> GetById(Guid id);
    }
}
