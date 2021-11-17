using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public bool Active { get; set; }

        /*EF Relations*/
        public virtual ICollection<CategoryExtra> CategoryExtras { get; set; }
    }
}
