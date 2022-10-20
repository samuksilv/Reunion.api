using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reunion.api.Domain.DTOS.Usuario;
using Reunion.api.Domain.UseCases.Usuario;

namespace Reunion.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly CriarUsuarioUseCase _criarUsuarioUC;
        private readonly AlterarUsuarioUseCase _alterarUsuarioUC;

        public UsuarioController(CriarUsuarioUseCase criarUsuarioUC, AlterarUsuarioUseCase alterarUsuarioUC)
        {
            _criarUsuarioUC = criarUsuarioUC;
            _alterarUsuarioUC = alterarUsuarioUC;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CriarUsuarioAsync([FromBody] CriarUsuarioDto usuarioDto)
        {
            var usuarioCriado = await _criarUsuarioUC.Execute(usuarioDto);

            return Created(string.Empty, usuarioCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CriarUsuarioAsync([FromRoute] string id, [FromBody] CriarUsuarioDto usuarioDto)
        {
            var usuarioAlterado = await _alterarUsuarioUC.Execute(Guid.Parse(id), usuarioDto);

            return Ok(usuarioAlterado);
        }

    }
}