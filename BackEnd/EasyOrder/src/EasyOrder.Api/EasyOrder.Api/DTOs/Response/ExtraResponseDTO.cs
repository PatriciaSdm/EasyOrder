using System;
using System.Collections.Generic;

namespace EasyOrder.Api.DTOs.Response
{
    public class ExtraResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public IEnumerable<KeyValueResponseDTO> Categories { get; set; }
    }
}
