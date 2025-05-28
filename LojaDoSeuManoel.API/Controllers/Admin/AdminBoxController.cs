using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers.Admin
{
    [Route("api/admin/box")]
    [ApiController]
    [Authorize]
    public class AdminBoxController : ControllerBase
    {
        public async Task<IActionResult> GetBoxes()
        {
            // Implement logic to retrieve boxes
            return Ok("List of boxes");
        }
        public async Task<IActionResult> GetBoxByType(int id)
        {
            // Implement logic to retrieve a box by its ID
            return Ok($"Details of box with ID: {id}");
        }
        public async Task<IActionResult> CreateBox([FromBody] CreateBox)
        {
            // Implement logic to create a new box
            return Created("api/admin/box/1", "New box created");
        }

    }
}
