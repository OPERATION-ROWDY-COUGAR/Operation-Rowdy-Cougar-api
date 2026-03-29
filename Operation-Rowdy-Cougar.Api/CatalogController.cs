using Microsoft.AspNetCore.Mvc;
using Operation.Rowdy.Cougar.Domain.Catalog;

namespace Operation.Rowdy.Cougar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok("hello world.");
        }
    }
}