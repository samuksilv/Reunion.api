using Microsoft.AspNetCore.Identity;
using Reunion.api.Domain.DTOS.Usuario;

namespace Reunion.api.Domain.UseCases.Usuario
{
    public class AlterarUsuarioUseCase
    {
        private readonly UserManager<Entities.Usuario> _userManager;

        public AlterarUsuarioUseCase(UserManager<Entities.Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UsuarioDto> Execute(Guid id, CriarUsuarioDto usuario)
        {
            var usuarioEntity = await _userManager.FindByIdAsync(id.ToString());

            usuarioEntity.Nome = usuario.Nome;
            usuarioEntity.Sobrenome = usuario.Sobrenome;
            usuarioEntity.Email = usuario.Email;

            var resultado = await _userManager.UpdateAsync(usuarioEntity);

            if (!resultado.Succeeded) throw new Exception(resultado.ToString());

            return (UsuarioDto)usuarioEntity;
        }
    }
}