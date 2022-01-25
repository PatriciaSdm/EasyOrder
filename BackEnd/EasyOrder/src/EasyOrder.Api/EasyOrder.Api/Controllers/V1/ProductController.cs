using AutoMapper;
using EasyOrder.Api.Controllers;
using EasyOrder.Api.DTOs.Request;
using EasyOrder.Api.DTOs.Response;
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
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> Get(Guid id)
        {
            var product = _mapper.Map<ProductResponseDTO>(await _productService.GetById(id));
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet]
        [ClaimsAuthorize("Products", "Read")]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAll()
        {
            var products = _mapper.Map<IEnumerable<ProductResponseDTO>>(await _productService.GetAll());

            return Ok(products);
        }

        [HttpGet("with-categories/{id:guid}")]
        [ClaimsAuthorize("Products", "Read")]
        public async Task<ActionResult<ProductResponseDTO>> GetWithCategory(Guid id)
        {
            var product = _mapper.Map<ProductResponseDTO>(await _productService.GetWithCategory(id));
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet("with-categories")]
        [ClaimsAuthorize("Products", "Read")]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetWithCategory()
        {
            var products = _mapper.Map<IEnumerable<ProductResponseDTO>>(await _productService.GetWithCategory());

            return Ok(products);
        }

        [HttpGet("catalog")]
        [ClaimsAuthorize("Products", "Read")]
        public async Task<ActionResult<IEnumerable<CatalogResponseDTO>>> GetCatalog()
        {
            var products = await _productService.GetWithCategoryAndExtras();

            return Ok(ProductsToCatalogResponseDTO(products));
        }

        private List<CatalogResponseDTO> ProductsToCatalogResponseDTO(List<Product> products)
        {
            return products.GroupBy(x => x.Category)
                            .Select(g => new CatalogResponseDTO
                            {
                                Category = g.Key.Name,
                                Extras = _mapper.Map<IEnumerable<KeyValueResponseDTO>>(g.Key.CategoryExtras.Select(x => x.Extra)),
                                Products = _mapper.Map<IEnumerable<ProductResponseDTO>>(g.ToList())
                            }).ToList();
        }

        [HttpPost]
        [ClaimsAuthorize("Products", "Include")]
        public async Task<ActionResult<bool>> Include(ProductRequestDTO productRequestDTO)
        {

            //if (!ModelState.IsValid) return CustomResponse(ModelState);

            

            return CustomResponse(await _productService.Include(_mapper.Map<Product>(productRequestDTO)));
        }

        [HttpPut]
        [ClaimsAuthorize("Products", "Update")]
        public async Task<ActionResult<bool>> Update(ProductRequestDTO productRequestDTO)
        {

            //if (!ModelState.IsValid) return CustomResponse(ModelState);


            return CustomResponse(await _productService.Update(_mapper.Map<Product>(productRequestDTO)));
        }

      
    }
}
