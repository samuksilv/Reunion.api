using Reunion.api.Domain.Entities.Interfaces;

namespace Reunion.api.Domain.Entities;

public class Sala : Entity
{
    public string Nome { get; set; }
    public string Local { get; set; }
    public virtual List<Agendamento>? Agendamentos { get; set; }
}