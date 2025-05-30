using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Application.Interfaces.Costumer;
using LojaDoSeuManoel.Application.Services.Admin;
using LojaDoSeuManoel.Application.Services.Costumer;
using LojaDoSeuManoel.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace LojaDoSeuManoel.API.Controllers.Admin
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = RolesTypes.Admin)]
    public class AdminOrderController : ControllerBase
    {

        private readonly IOrderInterface _orderService;

        private readonly IAdminOrderInterface _adminOrderService;
        public AdminOrderController(IOrderInterface orderService, IAdminOrderInterface adminOrderService)
        {
            _adminOrderService = adminOrderService;
            _orderService = orderService;
        }

        //Querys

        [HttpGet("allOrders")]
        public async Task<IActionResult> GetAllOrdersAdmin()
        {
            var response= await _adminOrderService.GetAllOrdersAdmin();

            if(response.Status is false)
            {
                return BadRequest(response);
            }
             
            return Ok(response);
        }

        [HttpGet("orderCustomer")]
        public async Task<IActionResult> GetOrderByIdAdmin([FromQuery] string email)
        {
            
            var response = await _adminOrderService.GetOrderByCustomerAdmin(email);
            if (response.Status is false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("orderByEmail")]
        public async  Task<IActionResult> GetOrderByEmailCustomerAdmin([FromQuery] string email)
        {
            var response = await _adminOrderService.GetOrderByCustomerAdmin(email);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        //Commands
        [HttpPut("updateStatusToCancelled")]
        public async Task<IActionResult> UpdateOrderToCancelledAdmin([FromQuery] int orderId)
        {
            var response = await _adminOrderService.UpdateOrderToCancelledAdmin(orderId);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
