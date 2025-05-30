using LojaDoSeuManoel.Application.Interfaces.Costumer;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers.Customer
{
    [Route("api/customerProductGame")]
    [ApiController]
    [Authorize(Roles=RolesTypes.Customer)]
    public class CustomerProductGameController : ControllerBase
    {

        private readonly IProductGameInterface _productGameService;
        public CustomerProductGameController(IProductGameInterface productGameService)
        {
            _productGameService = productGameService;
        }

        //Querys
        [HttpGet("allGames")]
        public async Task<IActionResult> GetAllGames()
        {
            var response = await _productGameService.GetAllProductGames();

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("gameByData")]
        public async Task<IActionResult> GetGameByName([FromQuery] string data)
        {
            var response = await _productGameService.GetProductGameByNameOrDescription(data);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("gameByCategory")]
        public async Task<IActionResult> GetGameByCategory([FromQuery] ProductGameCategoryEnum category)
        {
            var response = await _productGameService.GetProductGameByCategory(category);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("gameByPrice")]
        public async Task<IActionResult> GetGameByPrice([FromQuery] decimal price)
        {
            var response = await _productGameService.GetProductGameByPrice(price);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
