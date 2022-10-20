using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reunion.api.Domain.DTOS.Auth;
using Reunion.api.Domain.DTOS.Usuario;
using Reunion.api.Domain.UseCases.Login;

namespace Reunion.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly EfetuarLoginUseCase _efetuarLoginUseCase;

        public AuthController(EfetuarLoginUseCase efetuarLoginUseCase)
        {
            _efetuarLoginUseCase = efetuarLoginUseCase;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            await _efetuarLoginUseCase.Execute(loginDto.Email, loginDto.Senha);

            return Ok();
        }

    }
}