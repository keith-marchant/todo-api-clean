using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Api.Controllers
{
    public class ItemsController : ApiController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
