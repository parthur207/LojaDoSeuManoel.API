using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers.Customer
{
    [Authorize]
    [ApiController]
    [Route("api/customerOrder")]
    public class CustomerOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
