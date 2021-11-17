using EasyOrder.Business.Enums;
using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.ViewModels
{
    public class ItemViewModel
    {
        public Guid IdOrder { get; set; }
        public Guid IdProduct { get; set; }
        public int Quantity { get; set; }
        public string Observation { get; set; }
        public StatusItem Status { get; set; }

        /* EF Relations */
        public OrderViewModel Order { get; set; }
        public ProductViewModel Product { get; set; }
        public ICollection<ExtraViewModel> Extras { get; set; }
    }
}
