using AutoMapper;
using EasyOrder.Api.ViewModels;
using EasyOrder.Business.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : MainController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService,
                                  IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetAll()
        {
            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetAll());

            return Ok(categories);
        }
    }
}
