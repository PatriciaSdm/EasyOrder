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
    public class ProductsController : MainController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService,
                                  IMapper mapper,
                                  INotifier notifier,
                                  IUser user) : base(notifier, user)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Get(Guid id)
        {
            var product = _mapper.Map<ProductViewModel>(await _productService.GetById(id));
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAll()
        {
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetAll());

            return Ok(products);
        }

        [HttpGet("with-categories/{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> GetWithCategory(Guid id)
        {
            var product = _mapper.Map<ProductViewModel>(await _productService.GetWithCategory(id));
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet("with-categories")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetWithCategory()
        {
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetWithCategory());

            return Ok(products);
        }

     
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Include(ProductViewModel productViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.Include(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }

        [HttpPut]
        public async Task<ActionResult<ProductViewModel>> Update(ProductViewModel productViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.Update(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }
    }
}
