using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TodoApp.Application.Entities;

namespace TodoApp.Api.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[Controller]")]
    public class VersionController : ControllerBase
    {
        [ProducesResponseType(typeof(ApiInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public ActionResult<string> GetApiVersion()
        {
            return Ok(new ApiInformation(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly()));
        }
    }
}
