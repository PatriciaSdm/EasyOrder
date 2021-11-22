using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.DTOs.Response
{
    public class CatalogResponseDTO
    {
        public string Category { get; set; }
        public IEnumerable<KeyValueResponseDTO> Extras { get; set; }
        public IEnumerable<ProductResponseDTO> Products { get; set; }
    }
}
