using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Models;
using EasyOrder.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Zombie.Tests.Mocks
{
    public class FakeProductRepository : IProductRepository
    {
        private List<Product> _products;
        public FakeProductRepository()
        {
            _products = new List<Product>();
        }

        public Task<IEnumerable<Product>> Find(Expression<Func<Product, bool>> predicate)
        {
            return Task.Run(() => _products.AsQueryable().Where(predicate).AsEnumerable());
        }

        public Task<List<Product>> GetAll()
        {
            return Task.Run(() => _products);
        }

        public Task<Product> GetById(Guid id)
        {
            return Task.Run(() => _products.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task Include(Product entity)
        {
            return Task.Run(() => _products.Add(entity.Clone()));
        }

        public bool IsActivated(Guid id)
        {
            return _products.Where(x => x.Id == id).FirstOrDefault().Active == true;
        }

        public Task Update(Product entity)
        {
            var entityFromList = _products.Where(x => x.Id == entity.Id).FirstOrDefault();
            entityFromList = entity.Clone();
            return Task.Run(() => _products.Where(x => x.Id == entity.Id).FirstOrDefault());
        }

        public Task Delete(Guid id)
        {
            return Task.Run(() => _products.RemoveAll(x => x.Id == id));
        }

        public Task<IEnumerable<Product>> GetByIdCategory(Guid idCategory)
        {
            return Task.Run(() => _products.Where(x => x.IdCategory == idCategory));
        }

        public Task UpdateAll(List<Product> products)
        {
            foreach (var product in products)
            {
                var entityFromList = _products.Where(x => x.Id == product.Id).FirstOrDefault();
                entityFromList = product.Clone();
            }
            return Task.Run(() => _products.Where(x => products.Select(y => y.Id).Contains(x.Id)));
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetWithCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetWithCategory()
        {
            throw new NotImplementedException();
        }
    }
}
