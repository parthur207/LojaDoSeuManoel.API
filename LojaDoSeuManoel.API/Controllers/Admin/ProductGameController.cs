using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.Admin;
using LojaDoSeuManoel.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RolesTypes.Admin)]
    public class ProductGameController : ControllerBase
    {
        private readonly IAdminProductGameInterface _adminProductGameService;
        public ProductGameController(IAdminProductGameInterface adminProductGameService)
        {
            _adminProductGameService = adminProductGameService;
        }

        //Querys
        [HttpGet("allGames")]
        public async Task<IActionResult> GetAllGames()
        {
            var response = await _adminProductGameService.GetAllProductGameAdmin();

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
       
        [HttpGet("gameByData")]
        public async Task<IActionResult> GetGameByName([FromQuery] string Data)
        {
            var response = await _adminProductGameService.GetProductGameByNameOrDescriptionAdmin(Data);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpGet("gameByCategory")]
        public async Task<IActionResult> GetGameByCategory([FromQuery] ProductGameCategoryEnum category)
        {
            var response = await _adminProductGameService.GetProductGameByCategoryAdmin(category);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("gameByStatus")]
        public async Task<IActionResult> GetGameByStatus([FromQuery] ProductGameStatusEnum status)
        {
            var response = await _adminProductGameService.GetProductGameByStatusAdmin(status);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("gameByPrice")]
        public async Task<IActionResult> GetGameByPrice([FromQuery] decimal Price)
        {
            var response = await _adminProductGameService.GetProductGameByPriceAdmin(Price);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("gameNoStock")]
        public async Task<IActionResult> GetGameNoStock()
        {
            var response = await _adminProductGameService.GetProductGameNoStockAdmin();

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("gameInactive")]
        public async Task<IActionResult> GetGameInactive()
        {
            var response = await _adminProductGameService.GetProductGameInactiveAdmin();

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        //Vendas
        [HttpGet("allSales")]
        public async Task<IActionResult> GetAllSales()
        {
            var response = await _adminProductGameService.GetAllSalesAdmin();

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("salesByCategory")]
        public async Task<IActionResult> GetSalesByCategory([FromQuery] ProductGameCategoryEnum category)
        {
            var response = await _adminProductGameService.GetAllSalesByCategoryAdmin(category);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("topFiveSales")]
        public async Task<IActionResult> GetTopFiveSales([FromQuery] ProductGameCategoryEnum category)
        {
            var response = await _adminProductGameService.GetTopFiveSalesAdmin(category);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        //Commands
        [HttpPost("createGame")]
        public async Task<IActionResult> CreateGame([FromBody] CreateProductGameModel model)
        {
            if (model is null)
            {
                return BadRequest("Modelo de criação inválido.");
            }

            var response = await _adminProductGameService.CreateProductGameAdmin(model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("updateGame/{ProductGameId}")]
        public async Task<IActionResult> UpdateGame([FromRoute] int ProductGameId, [FromBody] UpdateProductGameModel model)
        {
            if (model is null)
            {
                return BadRequest("Modelo de atualização inválido.");
            }

            var response = await _adminProductGameService.UpdateDataProductGameAdmin(ProductGameId, model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("updateGameStock/{ProductGameId}")]
        public async Task<IActionResult> UpdateGameStock([FromRoute] int ProductGameId, [FromQuery] int newStock)
        {
            if (newStock < 0)
            {
                return BadRequest("O estoque não pode ser negativo.");
            }

            var response = await _adminProductGameService.UpdateStockTotalAdmin(ProductGameId, newStock);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("updateGameStatus/{ProductGameId}")]
        public async Task<IActionResult> UpdateGameStatus([FromRoute] int ProductGameId, [FromQuery] ProductGameStatusEnum status)
        {
            var response = await _adminProductGameService.UpdateStatusProductGameAdmin(ProductGameId, status);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
