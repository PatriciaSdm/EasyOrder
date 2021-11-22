using EasyOrder.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.DTOs.Request
{
    public class OrderRequestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Table { get; set; }
        public StatusOrder Status { get; set; }
        public int Number { get; set; }
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public IEnumerable<ItemRequestDTO> Items { get; set; }
    }
}
