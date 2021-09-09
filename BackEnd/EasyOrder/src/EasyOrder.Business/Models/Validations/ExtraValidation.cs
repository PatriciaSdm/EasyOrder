using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Models.Validations
{
    public class ExtraValidation : AbstractValidator<Extra>
    {
        public ExtraValidation()
        {
            RuleFor(f => f.Name)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 100)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
