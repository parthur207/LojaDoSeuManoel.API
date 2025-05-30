using LojaDoSeuManoel.Application.Interfaces.Generic;
using LojaDoSeuManoel.Domain.Models.Customer;
using LojaDoSeuManoel.Domain.Models.Generic;
using LojaDoSeuManoel.Infrastructure.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers.Generic
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthGenericController : ControllerBase
    {
        private readonly IAuthGenericInterface _authService;
        private readonly IJwtInterface _jwtInterface;
        public AuthGenericController(IAuthGenericInterface authService, IJwtInterface jwtInterface)
        {
            _authService = authService;
            _jwtInterface = jwtInterface;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model is null)
            {
                return BadRequest("Dados de login inválidos.");
            }

            var response = await _authService.ValidationCredentials(model);

            if (response.Status is false)
            {
                return Unauthorized(response);
            }
            var userDatas = await _authService.GetUserData(model.Email);

            if (userDatas.Status is false)
            {
                return Unauthorized(userDatas);
            }

            var token = _jwtInterface.GenerateToken(userDatas.Content, model.Email);

            return Ok(new { Response = "Login efetuado com sucesso.", Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateCustomerModel model)
        {
            if (model is null)
            {
                return BadRequest("Dados de registro inválidos.");
            }

            var response = await _authService.CreateNewCustomer(model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
