using LojaDoSeuManoel.Application.Interfaces.Costumer;
using LojaDoSeuManoel.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LojaDoSeuManoel.API.Controllers.Customer
{
    [ApiController]
    [Route("api/customerOrder")]
    [Authorize(Roles = RolesTypes.Customer)]
    public class CustomerOrderController : ControllerBase
    {
        private readonly IOrderInterface _orderService;

        public CustomerOrderController(IOrderInterface orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("allOrders")]
        public async Task<IActionResult> CustomerGetAllOrders()
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _orderService.GetAllOrders(userId);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
