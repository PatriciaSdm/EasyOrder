using AutoMapper;
using EasyOrder.Api.Extensions;
using EasyOrder.Api.ViewModels;
using EasyOrder.Business.Interfaces.INotifications;
using EasyOrder.Business.Interfaces.Services;
using EasyOrder.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyOrder.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : MainController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService,
                                  IMapper mapper,
                                  INotifier notifier) : base(notifier)
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

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Get(Guid id)
        {
            var category = _mapper.Map<CategoryViewModel>(await _categoryService.GetById(id));
            if (category == null) return NotFound();

            return Ok(category);
        }

        [ClaimsAuthorize("Categories", "Include")]
        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> Include(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoryService.Include(_mapper.Map<Category>(categoryViewModel));

            return CustomResponse(categoryViewModel);
        }

        [ClaimsAuthorize("Categories", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoryViewModel>> Update(Guid id, CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.Id)
            {
                NotifyError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(categoryViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoryService.Update(_mapper.Map<Category>(categoryViewModel));

            return CustomResponse(categoryViewModel);
        }
    }
}
