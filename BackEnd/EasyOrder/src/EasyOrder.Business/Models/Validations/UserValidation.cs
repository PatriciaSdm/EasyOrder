﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyOrder.Business.Models.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(c => c.Name)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.Email)
              .NotEmpty().WithMessage("É necessário fornecer o email do produto");
        }
    }
}
