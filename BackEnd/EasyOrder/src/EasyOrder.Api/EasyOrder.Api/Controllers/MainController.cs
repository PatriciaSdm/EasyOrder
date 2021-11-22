using System;
using System.Linq;
using EasyOrder.Api.ViewModels;
using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Interfaces.INotifications;
using EasyOrder.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EasyOrder.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        public readonly IUser AppUser;

        protected Guid UserId { get; set; }
        protected bool AuthenticatedUser { get; set; }

        public MainController(INotifier notifier,
            IUser appUser)
        {
            _notifier = notifier;
            AppUser = appUser;

            if (AppUser.IsAuthenticated())
            {
                UserId = appUser.GetUserId();
                AuthenticatedUser = true;
            }
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
