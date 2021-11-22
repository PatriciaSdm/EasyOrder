using EasyOrder.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.DTOs.Response
{
    public class ItemResponseDTO
    {
        public Guid Id { get; set; }
        public KeyValueResponseDTO Product { get; set; }
        public int Quantity { get; set; }
        public string Observation { get; set; }
        public StatusItem Status { get; set; }

        public ICollection<KeyValueResponseDTO> Extras { get; set; }
    }
}
