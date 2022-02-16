using EasyOrder.Business.Interfaces.INotifications;
using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Interfaces.Services;
using EasyOrder.Business.Models;
using EasyOrder.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Business.Services
{
    public class UserService : Service, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(INotifier notifier,
                              IUserRepository userRepository) : base(notifier)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll()
        {
          return await _userRepository.GetAll();
        }

        public Task<User> GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public async Task<bool> Include(User user)
        {
            if (!ExecutarValidacao(new UserValidation(), user)) return false;

            if (_userRepository.Find(f => f.Email.Address == user.Email.Address).Result.Any())
            {
                Notify("Já existe um usuário com este email informado.");
                return false;
            }

            await _userRepository.Include(user);
            return true;
        }

        public async Task<bool> Update(User user)
        {
            if (!ExecutarValidacao(new UserValidation(), user)) return false;

            if (_userRepository.Find(f => f.Email == user.Email && f.Id != user.Id).Result.Any())
            {
                Notify("Já existe um usuário com este email informado.");
                return false;
            }

            await _userRepository.Update(user);
            return true;
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
