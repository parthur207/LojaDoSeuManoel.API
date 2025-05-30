using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers.Admin
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = RolesTypes.Admin)]
    public class AdminBoxController : ControllerBase 
    {
        private readonly IAdminBoxInterface _adminBoxService;
        public AdminBoxController(IAdminBoxInterface adminBoxService)
        {
            _adminBoxService = adminBoxService;
        }

        [HttpGet("allBox")]
        public async Task<IActionResult> GetAllBoxes()
        {
            var response=_adminBoxService.GetAllBoxesAdmin();

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("box/{type}")]
        public async Task<IActionResult> GetBoxByType([FromQuery] BoxTypeEnum type)
        {
            var response=_adminBoxService.GetBoxByTypeAdmin(type);

            if (response.Status is false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
