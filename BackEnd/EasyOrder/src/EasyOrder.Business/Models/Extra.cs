using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Models
{
    public class Extra : Entity
    {
        public string Name { get; set; }
        public bool Active { get; set; }


        /* EF Relations */
        public ICollection<Category> Categories { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
