using AutoMapper;
using EasyOrder.Api.Controllers;
using EasyOrder.Api.Extensions;
using EasyOrder.Api.ViewModels;
using EasyOrder.Business.Interfaces;
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

namespace EasyOrder.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CategoriesController : MainController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService,
                                  IMapper mapper,
                                  INotifier notifier,
                                  IUser user) : base(notifier, user)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [ClaimsAuthorize("Categories", "Read")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _categoryService.GetAll();

            return Ok(categories);
        }

        //[AllowAnonymous]
        [ClaimsAuthorize("Categories", "Read")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<Category>>> Get(Guid id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null) return NotFound();

            return Ok(category);
        }

        [ClaimsAuthorize("Categories", "Include")]
        [HttpPost]
        public async Task<ActionResult<bool>> Include(Category category)
        {
            //if (AuthenticatedUser)
            //    AppUser.Name
            //    UserId

            //if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _categoryService.Include(category));
        }

        [ClaimsAuthorize("Categories", "Update")]
        [HttpPut()]
        public async Task<ActionResult<bool>> Update(/*Guid id, */Category category)
        {
            //if (id != categoryViewModel.Id)
            //{
            //    NotifyError("O id informado não é o mesmo que foi passado na query");
            //    return CustomResponse(categoryViewModel);
            //}

            //if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _categoryService.Update(_mapper.Map<Category>(category)));
        }
    }
}
