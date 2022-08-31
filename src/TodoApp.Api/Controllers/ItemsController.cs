using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Api.Controllers
{
    public class ItemsController : ApiController
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
