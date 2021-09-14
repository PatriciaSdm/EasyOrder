using AutoMapper;
using EasyOrder.Api.ViewModels;
using EasyOrder.Business.Interfaces.Services;
using EasyOrder.Business.Models;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetAll()
        {
            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetAll());

            return Ok(categories);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Get(Guid id)
        {
            var category = _mapper.Map<CategoryViewModel>(await _categoryService.GetById(id));
            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> Include(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var category = _mapper.Map<Category>(categoryViewModel);
            var result = await _categoryService.Include(category);

            if (!result) return BadRequest();

            return Ok(category);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoryViewModel>> Update(Guid id, CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var category = _mapper.Map<Category>(categoryViewModel);
            var result = await _categoryService.Update(category);

            if (!result) return BadRequest();

            return Ok(category);
        }
    }
}
