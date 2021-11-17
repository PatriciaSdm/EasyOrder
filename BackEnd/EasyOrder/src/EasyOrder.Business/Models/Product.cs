using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("IdCategory")]
        public Category Category { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
