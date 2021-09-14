using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Zombie.Tests.Mocks
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> Find(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Include(Category entity)
        {
            throw new NotImplementedException();
        }

        public bool IsActivated(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
