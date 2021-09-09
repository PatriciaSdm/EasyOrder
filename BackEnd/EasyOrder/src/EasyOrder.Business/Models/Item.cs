using EasyOrder.Business.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Models
{
    public class Item : Entity
    {
        public Guid IdOrder { get; set; }
        public Guid IdProduct { get; set; }
        public int Quantity { get; set; }
        public string Observation { get; set; }
        public StatusItem Status { get; set; }

        /* EF Relations */
        public Order Order { get; set; }
        public Product Product { get; set; }
        public ICollection<Extra> Extras { get; set; }
    }
}
