using LojaDoSeuManoel.Application.Interfaces.Costumer;
using LojaDoSeuManoel.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers.Customer
{
    [ApiController]
    [Route("api/customerOrder")]
    [Authorize(Roles = RolesTypes.Customer)]
    public class CustomerOrderController : Controller
    {
        private readonly IOrderInterface _orderService;

        public CustomerOrderController(IOrderInterface orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> GettAllOrders()
        {
            var response = await _orderService.GetAllOrders();

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
            
        }
    }
}
