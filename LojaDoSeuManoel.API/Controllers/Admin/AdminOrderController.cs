using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Application.Interfaces.Costumer;
using LojaDoSeuManoel.Application.Services.Admin;
using LojaDoSeuManoel.Application.Services.Costumer;
using LojaDoSeuManoel.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LojaDoSeuManoel.API.Controllers.Admin
{
    [Route("api/admin")]
    [ApiController]
    [Authorize]
    public class AdminOrderController : ControllerBase
    {

        private readonly IOrderInterface _orderService;

        private readonly IAdminOrderInterface _adminOrderService;
        public AdminOrderController(IOrderInterface orderService, IAdminOrderInterface adminOrderService)
        {
            _adminOrderService = adminOrderService;
            _orderService = orderService;
        }

        [Authorize(Roles=RolesTypes.Admin)]
        [HttpGet("allOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            
             var response= _orderService.GetOrders();

            if(response.Status is false)
            {
                return NoContent(response);
            }
             


            return Ok(response);*/
            
        }

        public async Task<IActionResult> GetOrderById(int id)
        {
            /*
            var response = _orderService.GetOrderById(id);
            if (response.Status is false)
            {
                return NoContent(response);
            }
            return Ok(response);*/
        }

        public async  Task<IActionResult> UpdateOrderStatus()
        {

        }
    }
}
