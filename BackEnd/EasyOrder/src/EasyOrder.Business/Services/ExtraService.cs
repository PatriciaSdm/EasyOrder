using EasyOrder.Business.Interfaces.INotifications;
using EasyOrder.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Services
{
    public class ExtraService : Service, IExtraService
    {
        public ExtraService(INotifier notifier) : base(notifier)
        {

        }
    
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
