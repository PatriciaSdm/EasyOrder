using EasyOrder.Business.Interfaces.INotifications;
using EasyOrder.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Services
{
    public class CategoryService : Service, ICategoryService
    {
        public CategoryService(INotifier notifier) : base(notifier)
        {

        }
    
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
