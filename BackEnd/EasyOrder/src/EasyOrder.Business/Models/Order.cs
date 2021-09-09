using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Models
{
    public class Order : Entity
    {
        public string Name { get; set; }
        public int Table { get; set; }
        public int MyProperty { get; set; }
        public int Status { get; set; }
        //public User Waiter { get; set; }
        public int Code { get; set; }
    }
}
