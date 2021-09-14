using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyOrder.Api.ViewModels;
using EasyOrder.Business.Interfaces.INotifications;
using EasyOrder.Business.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EasyOrder.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool IsOperationValid()
        {
            return !_notifier.HasNotification();
        }
        protected ActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(new ResponseViewModel
                {
                    success = true,
                    data = result
                });
            }


            return BadRequest(new ResponseViewModel
            {
                success = false,
                errors = _notifier.GetNotifications().Select(x => x.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyModelErrorInvalid(modelState);
            return CustomResponse();
        }

        protected void NotifyModelErrorInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(x => x.Errors);
            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMessage);
            }
        }

        protected void NotifyError(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}
