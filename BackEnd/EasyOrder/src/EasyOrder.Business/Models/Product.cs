using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid IdCategory { get; set; }
        public bool Active { get; set; }


        /* EF Relations */
        public Category Category { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
