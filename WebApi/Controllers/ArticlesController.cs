using Application;
using Application.Exceptions;
using Application.Handlers.Articles.Commands.Create;
using Application.Handlers.Articles.Commands.Delete;
using Application.Handlers.Articles.Commands.Update;
using Application.Handlers.Articles.Queries.GetArticle;
using Application.Handlers.Articles.Queries.GetArticles;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //test
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

        [HttpPost]
        [Route("AddArticle")]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand command)
        {
            var actionName = ControllerContext.ActionDescriptor.ActionName;

            try
            {
                _logger.LogMessage(actionName, JsonConvert.SerializeObject(command), LogEventLevel.Information);
                return Ok(await Mediator.Send(command));
            }
            catch (ValidationException exception)
            {
                return StatusCode(badRequestErrorCode, JsonConvert.SerializeObject(exception.Failures));
            }
            catch (Exception exception)
            {
                _logger.LogException(exception, actionName, JsonConvert.SerializeObject(command) + " " + JsonConvert.SerializeObject(command));
                return StatusCode(internalServerErrorCode, _configuration.ErrorMessage);
            }
        }

        [HttpPut]
        [Route("UpdateArticle")]
        public async Task<IActionResult> UpdateArticle([FromBody] UpdateArticleCommand command)
        {
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            try
            {
                _logger.LogMessage(actionName, JsonConvert.SerializeObject(command), LogEventLevel.Information);
                return Ok(await Mediator.Send(command));
            }
            catch (ValidationException exception)
            {
                return StatusCode(badRequestErrorCode, JsonConvert.SerializeObject(exception.Failures));
            }
            catch (Exception exception)
            {
                _logger.LogException(exception, actionName, JsonConvert.SerializeObject(command) + " " + JsonConvert.SerializeObject(command));
                return StatusCode(internalServerErrorCode, _configuration.ErrorMessage);
            }
        }

        [HttpDelete]
        [Route("DeleteArticle")]
        public async Task<IActionResult> DeleteArticle([FromBody] DeleteArticleCommand command)
        {
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            try
            {
                _logger.LogMessage(actionName, JsonConvert.SerializeObject(command), LogEventLevel.Information);
                return Ok(await Mediator.Send(command));
            }
            catch (ValidationException exception)
            {
                return StatusCode(badRequestErrorCode, JsonConvert.SerializeObject(exception.Failures));
            }
            catch (DbUpdateConcurrencyException exception)
            {
                _logger.LogException(exception, actionName, JsonConvert.SerializeObject(command) + " " + JsonConvert.SerializeObject(command));
                return StatusCode(notFoundErrorCode, _configuration.DisplayObjectNotFoundErrorMessage);
            }
            catch (Exception exception)
            {
                _logger.LogException(exception, actionName, JsonConvert.SerializeObject(command) + " " + JsonConvert.SerializeObject(command));
                return StatusCode(internalServerErrorCode, _configuration.ErrorMessage);
            }
        }
    }
}
