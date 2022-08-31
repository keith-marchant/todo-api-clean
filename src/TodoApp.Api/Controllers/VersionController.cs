using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TodoApp.Api.ProblemDetails;
using TodoApp.Application.Entities;

namespace TodoApp.Api.Controllers
{
    /// <summary>
    /// Default controller providing access to the compiled API SemVer.
    /// </summary>
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[Controller]")]
    public class VersionController : ControllerBase
    {
        /// <summary>
        /// Get the compiled API SemVer.
        /// </summary>
        /// <returns>The API SemVer.</returns>
        /// <example>1.0.0.0</example>
        [ProducesResponseType(typeof(ApiInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UnhandledExceptionProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public ActionResult<string> GetApiVersion()
        {
            return Ok(new ApiInformation(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly()));
        }
    }
}
