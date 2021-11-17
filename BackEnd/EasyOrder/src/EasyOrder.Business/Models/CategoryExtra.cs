using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EasyOrder.Business.Models
{
    public class CategoryExtra 
    {
        public Guid IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public Category Category { get; set; }

        public Guid IdExtra { get; set; }
        [ForeignKey("IdExtra")]
        public Extra Extra { get; set; }
    }
}
