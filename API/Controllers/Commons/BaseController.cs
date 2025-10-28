using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Commons
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator => _mediatr ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediatr;
        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();
        private ISender? _sender;    //test
    }
}