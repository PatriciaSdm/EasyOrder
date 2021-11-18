using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.ViewModels
{
    public class ExtraViewModel
    {
        //[Key]
        public Guid Id { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Active { get; set; }

        //[Required(ErrorMessage = "É necessário fornecer no minimo uma {0}")]
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
