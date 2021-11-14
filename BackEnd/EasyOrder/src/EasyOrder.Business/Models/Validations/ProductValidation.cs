using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(c => c.Name)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.Price)
              .NotEmpty().WithMessage("É necessário fornecer o valor do produto");

            RuleFor(x => x.IdCategory)
             .NotEmpty().WithMessage("É necessário fornecer a categoria do produto");
        }
    }
}
