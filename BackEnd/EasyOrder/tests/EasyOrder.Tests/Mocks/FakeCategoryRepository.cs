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
    public class FakeCategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;
        public FakeCategoryRepository()
        {
            _categories = new List<Category>();
            _categories.Add(new Category { Id = Guid.NewGuid(), Name = "Pastel", Active = true });
            _categories.Add(new Category { Id = Guid.NewGuid(), Name = "Sushi", Active = false });
        }

        public Task<IEnumerable<Category>> Find(Expression<Func<Category, bool>> predicate)
        {
            return Task.Run(() => _categories.AsQueryable().Where(predicate).AsEnumerable());
        }

        public Task<List<Category>> GetAll()
        {
            return Task.Run(() => _categories);
        }

        public Task<Category> GetById(Guid id)
        {
            return Task.Run(() => _categories.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task Include(Category entity)
        {
            return Task.Run(() => _categories.Add(entity.Clone()));
        }

        public bool GetActiveStatus(Guid id)
        {
            return _categories.Where(x => x.Id == id).FirstOrDefault().Active;
        }

        public Task Update(Category entity)
        {
            var entityFromList = _categories.Where(x => x.Id == entity.Id).FirstOrDefault();
            entityFromList = entity.Clone();
            return Task.Run(() => _categories.Where(x => x.Id == entity.Id).FirstOrDefault());
        }

        public Task Delete(Guid id)
        {
            return Task.Run(() => _categories.RemoveAll(x => x.Id == id));
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
