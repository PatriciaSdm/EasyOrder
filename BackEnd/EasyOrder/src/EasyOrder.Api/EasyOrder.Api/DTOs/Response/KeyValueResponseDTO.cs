using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.DTOs.Response
{
    public class KeyValueResponseDTO
    {
        public Guid Key { get; set; }
        public string Value { get; set; }
    }
}
