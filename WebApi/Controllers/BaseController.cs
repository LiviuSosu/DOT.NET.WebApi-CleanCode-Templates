using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers
{
    public class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected const int badRequestErrorCode = 400;
        protected const int notFoundErrorCode = 404;
        protected const int internalServerErrorCode = 500;

        protected readonly IConfiguration _configuration;
        protected readonly ILogger _logger;
        public BaseController(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
    }
}
