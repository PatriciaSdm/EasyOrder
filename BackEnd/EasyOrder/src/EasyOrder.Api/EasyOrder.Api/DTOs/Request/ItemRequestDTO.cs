using EasyOrder.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.DTOs.Request
{
    public class ItemRequestDTO
    {
        public Guid Id { get; set; }
        public Guid IdProduct { get; set; }
        public int Quantity { get; set; }
        public string Observation { get; set; }
        public StatusItem Status { get; set; }
        public ICollection<Guid> Extras { get; set; }
    }
}
