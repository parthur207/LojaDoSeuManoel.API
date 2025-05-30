using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers.Admin
{
    [Route("api/admin/customer")]
    [ApiController]
    [Authorize(Roles=RolesTypes.Admin)]
    public class AdminCustomerController : ControllerBase
    {
        private readonly IAdminCustomerInterface _adminCustomerService;

        public AdminCustomerController(IAdminCustomerInterface adminCustomerService)
        {
            _adminCustomerService = adminCustomerService;
        }

        //Querys

        [HttpGet("allCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var response = await _adminCustomerService.GetAllCustomersAdmin();

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("byEmail")]
        public async Task<IActionResult> GetCustomerByEmail([FromQuery] string email)
        {
            var response = await _adminCustomerService.GetCustomerByEmailAdmin(email);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        //Commands
        [HttpPut("inactivate")]
        public async Task<IActionResult> InactivateCustomer([FromQuery] string email)
        {
            var response = await _adminCustomerService.InactivateCustomerAdmin(email);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("activate")]
        public async Task<IActionResult> ActivateCustomer([FromQuery] string email)
        {
            var response = await _adminCustomerService.ActiveCustomerAdmin(email);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
