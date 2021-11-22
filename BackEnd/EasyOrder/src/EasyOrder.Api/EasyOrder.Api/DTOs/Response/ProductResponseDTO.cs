using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.DTOs.Response
{
    public class ProductResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Code { get; set; }
        public KeyValueResponseDTO Category { get; set; }
        public bool Active { get; set; }
    }
}
