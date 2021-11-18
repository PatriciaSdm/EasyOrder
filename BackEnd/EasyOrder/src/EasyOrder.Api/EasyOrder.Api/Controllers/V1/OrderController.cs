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
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> Get(Guid id)
        {
            var order = _mapper.Map<OrderViewModel>(await _orderService.Get(id));
            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> Get()
        {
            var orders = _mapper.Map<IEnumerable<OrderViewModel>>(await _orderService.Get());

            return Ok(orders);
        }


        [HttpGet("with-itens/{id:guid}")]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetWithItens(Guid id)
        {
            var order = _mapper.Map<OrderViewModel>(await _orderService.GetWithItens(id));
            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpGet("with-itens")]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetWithItens()
        {
            var orders = _mapper.Map<IEnumerable<OrderViewModel>>(await _orderService.GetWithItens());

            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<OrderViewModel>> Include(OrderViewModel orderViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _orderService.Include(_mapper.Map<Order>(orderViewModel));

            return CustomResponse(orderViewModel);
        }

        [HttpPut]
        public async Task<ActionResult<OrderViewModel>> Update(OrderViewModel orderViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _orderService.Update(_mapper.Map<Order>(orderViewModel));

            return CustomResponse(orderViewModel);
        }
    }
}
