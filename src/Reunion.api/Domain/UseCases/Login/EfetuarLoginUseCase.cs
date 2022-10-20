using Microsoft.AspNetCore.Identity;
using Reunion.api.Infra.Security;

namespace Reunion.api.Domain.UseCases.Login;

public class EfetuarLoginUseCase
{
    private readonly SignInManager<Entities.Usuario> _signInManager;

    public EfetuarLoginUseCase(SignInManager<Entities.Usuario> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task Execute(string email, string senha)
    {
        var resultado = await _signInManager.PasswordSignInAsync(email, senha, true, false);

        if (!resultado.Succeeded)
        {
            throw new Exception(resultado.ToString());
        }

        return;
    }
}

