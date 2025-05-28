using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LojaDoSeuManoel.API.Controllers.Admin
{
    [Route("api/admin/Order")]
    [ApiController]
    [Authorize]
    public class AdminOrderController : ControllerBase
    {

        public async Task<IActionResult> GetOrders()
        {
            /*
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
