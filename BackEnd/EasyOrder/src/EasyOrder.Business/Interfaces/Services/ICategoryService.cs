using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces.Services
{
    public interface ICategoryService : IDisposable
    {
        Task<bool> Include(Category category);
        Task<bool> Update(Category category);
        Task<Category> GetById(Guid id);
        Task<List<Category>> GetAll();
    }
}
