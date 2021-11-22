using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.DTOs.Request
{
    public class ProductRequestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Code { get; set; }
        public Guid IdCategory { get; set; }
        public bool Active { get; set; }
    }
}
