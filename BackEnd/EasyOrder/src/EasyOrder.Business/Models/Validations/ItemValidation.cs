using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Models.Validations
{
    public class ItemValidation : AbstractValidator<Item>
    {
        public ItemValidation()
        {
            
        }
    }
}
