using Microsoft.AspNetCore.Identity;
using Reunion.api.Domain.DTOS;
using Reunion.api.Domain.DTOS.Usuario;
using Reunion.api.Domain.Entities.Interfaces;
using Reunion.api.Infra.Security;

namespace Reunion.api.Domain.UseCases.Usuario;

public class CriarUsuarioUseCase
{
    private readonly UserManager<Entities.Usuario> _userManager;

    public CriarUsuarioUseCase(UserManager<Entities.Usuario> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UsuarioDto> Execute(CriarUsuarioDto usuario)
    {
        var usuarioEntity = new Entities.Usuario(Guid.NewGuid(), usuario.Nome, usuario.Sobrenome, usuario.Email, usuario.Senha);

        var resultado = await _userManager.CreateAsync(usuarioEntity, usuario.Senha);

        if (!resultado.Succeeded) throw new Exception(resultado.ToString());

        return (UsuarioDto)usuarioEntity;
    }

}