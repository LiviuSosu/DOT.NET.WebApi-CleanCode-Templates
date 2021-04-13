using Application;
using Application.Handlers.Articles.Queries.GetArticle;
using Application.Handlers.Articles.Queries.GetArticles;
using Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog.Events;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : BaseController
    {
        public ArticlesController(IConfiguration configuration, ILogger logger) :base(configuration, logger)
        {
        }

        [HttpGet]
        [Route("GetArticles")]
        public async Task<IActionResult> GetArticles([FromQuery] PagingModel paginationModel)
        {
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            try
            {
                _logger.LogMessage(actionName, JsonConvert.SerializeObject(paginationModel), LogEventLevel.Information);
                return Ok(await Mediator.Send(new GetArticlesListQuery(paginationModel)));
            }
            catch (Exception exception)
            {
                _logger.LogException(exception, actionName, JsonConvert.SerializeObject(paginationModel));
                return StatusCode(internalServerErrorCode, _configuration.ErrorMessage);
            }
        }

        [HttpGet]
        [Route("GetArticle")]
        public async Task<IActionResult> GetArticle([FromQuery] Guid Id)
        {
            var actionName = ControllerContext.ActionDescriptor.ActionName;

            try
            {
                _logger.LogMessage(actionName, JsonConvert.SerializeObject(Id), LogEventLevel.Information);
                return Ok(await Mediator.Send(new GetArticleQuery(Id)));
            }
            catch (Exception exception)
            {
                _logger.LogException(exception, actionName, JsonConvert.SerializeObject(Id));
                return StatusCode(internalServerErrorCode, _configuration.ErrorMessage);
            }
        }
    }
}
