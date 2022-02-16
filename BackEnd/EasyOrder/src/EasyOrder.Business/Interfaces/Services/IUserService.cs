using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Interfaces.Services
{
    public interface IUserService : IDisposable
    {
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<bool> Include(User product);
        Task<bool> Update(User model);
    }
}
