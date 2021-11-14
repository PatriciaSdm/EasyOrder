using EasyOrder.Business.Interfaces;
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
    public class CategoryService : Service, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUser _user;
        public CategoryService(ICategoryRepository categoryRepository,
                               IProductRepository productRepository,
                               INotifier notifier,
                               IUser user) : base(notifier)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _user = user;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<bool> Include(Category category)
        {
            //var user = _user.GetUserId();

            if (!ExecutarValidacao(new CategoryValidation(), category)) return false;

            if (_categoryRepository.Find(f => f.Name == category.Name).Result.Any())
            {
                Notify("Já existe uma categoria com este nome informado.");
                return false;
            }

            await _categoryRepository.Include(category);
            return true;
        }

        public async Task<bool> Update(Category category)
        {
            if (!ExecutarValidacao(new CategoryValidation(), category)) return false;

            if (_categoryRepository.Find(f => f.Name == category.Name && f.Id != category.Id).Result.Any())
            {
                Notify("Já existe uma categoria com este nome informado.");
                return false;
            }

            await ActiveOrDesactivateProducts(category);

            await _categoryRepository.Update(category);
            return true;
        }

        private async Task ActiveOrDesactivateProducts(Category category)
        {
            if (_categoryRepository.GetActiveStatus(category.Id) != category.Active)
            {
                var products = _productRepository.GetByIdCategory(category.Id).Result.ToList();
                products.ForEach(x => x.Active = category.Active);
                await _productRepository.UpdateAll(products);
            }
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
            _productRepository?.Dispose();
        }
    }
}
