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
    public class ExtraService : Service, IExtraService
    {
        private readonly IExtraRepository _extraRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ExtraService(INotifier notifier,
                              IExtraRepository extraRepository,
                              ICategoryRepository categoryRepository) : base(notifier)
        {
            _extraRepository = extraRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Extra>> GetAll()
        {
            return await _extraRepository.GetAll();
        }

        public async Task<bool> Include(Extra extra)
        {
            if (!ExecutarValidacao(new ExtraValidation(), extra)) return false;

            if (_extraRepository.Find(f => f.Name == extra.Name).Result.Any())
            {
                Notify("Já existe um adicional com este nome informado.");
                return false;
            }

            await _extraRepository.Include(extra);
            return true;
        }

        public async Task<bool> Update(Extra extra)
        {
            if (!ExecutarValidacao(new ExtraValidation(), extra)) return false;

            if (_extraRepository.Find(f => f.Name == extra.Name && f.Id != extra.Id).Result.Any())
            {
                Notify("Já existe um adicional com este nome informado.");
                return false;
            }

            // TODO: Update child relationship

            await _extraRepository.Update(extra);
            return true;
        }

        public async Task<Extra> GetById(Guid id)
        {
            return await _extraRepository.GetById(id);
        }

        public async Task<IEnumerable<Extra>> GetWithCategories()
        {
            return await _extraRepository.GetWithCategories();
        }

        public async Task<Extra> GetWithCategories(Guid id)
        {
          return  await _extraRepository.GetWithCategories(id);
        }

        public void Dispose()
        {
            _extraRepository?.Dispose();
        }
    }
}
