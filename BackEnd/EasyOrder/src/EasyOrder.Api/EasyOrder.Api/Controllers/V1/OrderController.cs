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
    public class OrderController : MainController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService,
                                  IMapper mapper,
                                  INotifier notifier,
                                  IUser user) : base(notifier, user)
        {
            _orderService = orderService;
            _mapper = mapper;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> Get(Guid id)
        {
            var order = _mapper.Map<OrderResponseDTO>(await _orderService.Get(id));
            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> Get()
        {
            var orders = _mapper.Map<IEnumerable<OrderResponseDTO>>(await _orderService.Get());

            return Ok(orders);
        }


        [HttpGet("with-itens/{id:guid}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetWithItens(Guid id)
        {
            var order = _mapper.Map<OrderResponseDTO>(await _orderService.GetWithItens(id));
            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpGet("with-itens")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetWithItens()
        {
            var orders = _mapper.Map<IEnumerable<OrderResponseDTO>>(await _orderService.GetWithItens());

            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Include(OrderRequestDTO orderViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);


            return CustomResponse(await _orderService.Include(_mapper.Map<Order>(orderViewModel)));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update(OrderRequestDTO orderViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _orderService.Update(_mapper.Map<Order>(orderViewModel)));
        }
    }
}
