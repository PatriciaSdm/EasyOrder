using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Enums
{
    public enum StatusOrder
    {
        New = 1,
        Awaiting = 2,
        Preparing = 3,
        Finished = 4,
        Closed = 5
    }
}
