using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.ViewModels
{
    public class ResponseViewModel
    {
        public bool success { get; set; }
        public object data { get; set; }
        public IEnumerable<string> errors { get; set; }
    }
}
