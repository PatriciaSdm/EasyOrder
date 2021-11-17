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
        public async Task<ActionResult<IEnumerable<ExtraViewModel>>> GetAll()
        {
            var extras = _mapper.Map<IEnumerable<ExtraViewModel>>(await _extraService.GetAll());

            return Ok(extras);
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<ExtraViewModel>>> Get(Guid id)
        {
            var extra = _mapper.Map<ExtraViewModel>(await _extraService.GetById(id));
            if (extra == null) return NotFound();

            return Ok(extra);
        }

        //[AllowAnonymous]
        [HttpGet("with-categories/{id:guid}")]
        public async Task<ActionResult<ExtraViewModel>> GetWithCategories(Guid id)
        {
            var extra = _mapper.Map<ExtraViewModel>(await _extraService.GetWithCategories(id));
            if (extra == null) return NotFound();

            return Ok(extra);
        }


        [HttpGet("with-categories")]
        public async Task<ActionResult<IEnumerable<ExtraViewModel>>> GetWithCategories()
        {
            var extra = _mapper.Map<IEnumerable<ExtraViewModel>>(await _extraService.GetWithCategories());
            if (extra == null) return NotFound();

            return Ok(extra);
        }

        //[ClaimsAuthorize("Extras", "Include")]
        [HttpPost]
        public async Task<ActionResult<ExtraViewModel>> Include(ExtraViewModel extraViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _extraService.Include(_mapper.Map<Extra>(extraViewModel));

            return CustomResponse(extraViewModel);
        }

        //[ClaimsAuthorize("Extras", "Update")]
        [HttpPut]
        public async Task<ActionResult<ExtraViewModel>> Update(ExtraViewModel extraViewModel)
        {
            //if (id != extraViewModel.Id)
            //{
            //    NotifyError("O id informado não é o mesmo que foi passado na query");
            //    return CustomResponse(extraViewModel);
            //}

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _extraService.Update(_mapper.Map<Extra>(extraViewModel));

            return CustomResponse(extraViewModel);
        }
    }
}
