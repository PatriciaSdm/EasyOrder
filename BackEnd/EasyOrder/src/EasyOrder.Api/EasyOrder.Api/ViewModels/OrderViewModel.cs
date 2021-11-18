using EasyOrder.Business.Enums;
using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Table { get; set; }
        public StatusOrder Status { get; set; }
        //public User Waiter { get; set; }
        public int Number { get; set; }
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}
