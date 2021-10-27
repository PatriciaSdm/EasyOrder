using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Interfaces.Services;
using EasyOrder.Business.Models;
using EasyOrder.Business.Notifications;
using EasyOrder.Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zombie.Tests.Mocks;

namespace EasyOrder.Tests
{
    [TestClass]
    public class CategoryServiceTest
    {
        private readonly FakeCategoryRepository _fakeCategoryRepository;
        private readonly FakeProductRepository _fakeProductRepository;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IUser _user;


        public CategoryServiceTest()
        {
            _fakeCategoryRepository = new FakeCategoryRepository();
            _fakeProductRepository = new FakeProductRepository();
            _categoryService = new CategoryService(_fakeCategoryRepository, _fakeProductRepository, new Notifier(), _user);
            _productService = new ProductService(new Notifier(), _fakeProductRepository);

        }

        [TestMethod]
        public async Task Shoud_Update_Products_Status_When_Update_Category_Status()
        {
            // Arrange
            var category = new Category { Id = Guid.NewGuid(), Name = "Sorvete", Active = true};
            var product = new Product { Id = Guid.NewGuid(), Name = "Açai", Active = true, IdCategory = category.Id, Description = "Sorvete sabor açaí", Price = 10 };

            await _categoryService.Include(category);
            await _productService.Include(product);

            // Act
            category.Active = false;
            await _categoryService.Update(category);

            // Assert
            List<Product> products = _productService.GetByCategoryId(category.Id).Result.ToList();
            Assert.IsFalse(products.Any(x => x.Active != category.Active));
        }
    }
}
