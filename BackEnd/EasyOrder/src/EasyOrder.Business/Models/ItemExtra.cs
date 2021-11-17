using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EasyOrder.Business.Models
{
    public class ItemExtra 
    {
        public Guid IdItem { get; set; }
        [ForeignKey("IdItem")]
        public Item Item { get; set; }

        public Guid IdExtra { get; set; }
        [ForeignKey("IdExtra")]
        public Extra Extra { get; set; }
    }
}
