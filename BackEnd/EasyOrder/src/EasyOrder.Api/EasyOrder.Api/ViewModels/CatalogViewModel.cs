using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.ViewModels
{
    public class CatalogViewModel
    {
        public string Category { get; set; }
        public IEnumerable<ExtraViewModel> Extras { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
