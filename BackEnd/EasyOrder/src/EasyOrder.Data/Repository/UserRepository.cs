using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Models;
using EasyOrder.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOrder.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EasyOrderContext context) : base(context)
        {
            
        }

    }
}
