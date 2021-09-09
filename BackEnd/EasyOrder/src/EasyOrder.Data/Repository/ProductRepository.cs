using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Models;
using EasyOrder.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EasyOrderContext context) : base(context)
        {
        }
    }
}
