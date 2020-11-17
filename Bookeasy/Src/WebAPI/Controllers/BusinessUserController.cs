using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BusinessUserController : BaseController
    {
        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}