using Common;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<string> GetArticles()
        {
            return "test";
        }
    }
}
