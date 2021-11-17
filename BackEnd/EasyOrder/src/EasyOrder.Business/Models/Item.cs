using EasyOrder.Business.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("IdOrder")]
        public Order Order { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        public ICollection<ItemExtra> ItemExtras { get; set; }

        public Item()
        {
            Status = StatusItem.New;
        }
    }
}
