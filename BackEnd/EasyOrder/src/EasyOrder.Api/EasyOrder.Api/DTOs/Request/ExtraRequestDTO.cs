using EasyOrder.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.DTOs.Request
{
    public class ExtraRequestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public IEnumerable<Guid> Categories { get; set; }
    }
}
