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
    public class ProductService : Service, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(INotifier notifier,
                              IProductRepository productRepository) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<bool> Include(Product product)
        {
            if (!ExecutarValidacao(new ProductValidation(), product)) return false;

            if (_productRepository.Find(f => f.Name == product.Name).Result.Any())
            {
                Notify("Já existe um produto com este nome informado.");
                return false;
            }

            await _productRepository.Include(product);
            return true;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetByCategoryId(Guid id)
        {
            return _productRepository.GetByIdCategory(id);
        }
    }
}
