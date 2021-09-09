using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Models;
using EasyOrder.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(EasyOrderContext context) : base(context)
        {
        }
    }
}
