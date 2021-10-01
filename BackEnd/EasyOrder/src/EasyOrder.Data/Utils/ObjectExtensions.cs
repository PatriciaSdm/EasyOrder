using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Data.Utils
{
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T self)
        {
            var serialized = JsonConvert.SerializeObject(self);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
