using EasyOrder.Business.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Models
{
    public class Order : Entity
    {
        public string Name { get; set; }
        public int Table { get; set; }
        public StatusOrder Status { get; set; }
        //public User Waiter { get; set; }
        public int Number { get; set; } //TODO: Gerar numero crescente
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }


        /* EF Relations */
        public IEnumerable<Item> Items { get; set; }

        public Order()
        {
            Status = StatusOrder.New;
        }
    }
}
