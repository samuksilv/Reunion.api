using Microsoft.AspNetCore.Identity;
using Reunion.api.Domain.Entities.Interfaces;
using Reunion.api.Infra.Security;

namespace Reunion.api.Domain.Entities;

public class Usuario : IdentityUser<Guid>
{
    public Usuario()
    {

    }

    public Usuario(Guid id, string nome, string sobrenome, string email, string senha)
    {
        Id = id;
        Nome = nome;
        Sobrenome = sobrenome;
        UserName = email;
        Email = email;
    }

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public virtual List<Agendamento>? Agendamentos { get; set; }
}