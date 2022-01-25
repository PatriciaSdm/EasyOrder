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
    public class ExtrasController : MainController
    {
        private readonly IExtraService _extraService;
        private readonly IMapper _mapper;
        public ExtrasController(IExtraService extraService,
                                  IMapper mapper,
                                  INotifier notifier,
                                  IUser user) : base(notifier, user)
        {
            _extraService = extraService;
            _mapper = mapper;
        }

        [HttpGet]
        [ClaimsAuthorize("Extras", "Read")]
        public async Task<ActionResult<IEnumerable<ExtraResponseDTO>>> GetAll()
        {
            var extras = _mapper.Map<IEnumerable<ExtraResponseDTO>>(await _extraService.GetAll());

            return Ok(extras);
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        [ClaimsAuthorize("Extras", "Read")]
        public async Task<ActionResult<IEnumerable<ExtraResponseDTO>>> Get(Guid id)
        {
            var extra = _mapper.Map<ExtraResponseDTO>(await _extraService.GetById(id));
            if (extra == null) return NotFound();

            return Ok(extra);
        }

        //[AllowAnonymous]
        [ClaimsAuthorize("Extras", "Read")]
        [HttpGet("with-categories/{id:guid}")]
        public async Task<ActionResult<ExtraResponseDTO>> GetWithCategories(Guid id)
        {
            var extra = _mapper.Map<ExtraResponseDTO>(await _extraService.GetWithCategories(id));
            if (extra == null) return NotFound();

            return Ok(extra);
        }

        [ClaimsAuthorize("Extras", "Read")]
        [HttpGet("with-categories")]
        public async Task<ActionResult<IEnumerable<ExtraResponseDTO>>> GetWithCategories()
        {
            var extra = _mapper.Map<IEnumerable<ExtraResponseDTO>>(await _extraService.GetWithCategories());
            if (extra == null) return NotFound();

            return Ok(extra);
        }

        [ClaimsAuthorize("Extras", "Include")]
        [HttpPost]
        public async Task<ActionResult<bool>> Include(ExtraRequestDTO extraRequestDTO)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _extraService.Include(_mapper.Map<Extra>(extraRequestDTO)));
        }

        [ClaimsAuthorize("Extras", "Update")]
        [HttpPut]
        public async Task<ActionResult<bool>> Update(ExtraRequestDTO extraRequestDTO)
        {
            //if (id != extraViewModel.Id)
            //{
            //    NotifyError("O id informado não é o mesmo que foi passado na query");
            //    return CustomResponse(extraViewModel);
            //}

            return CustomResponse(await _extraService.Update(_mapper.Map<Extra>(extraRequestDTO)));
        }
    }
}
