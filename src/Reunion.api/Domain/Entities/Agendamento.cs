using Reunion.api.Domain.Entities.Interfaces;

namespace Reunion.api.Domain.Entities;

public class Agendamento : Entity
{
    public Guid UsuarioId { get; set; }
    public Guid SalaId { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public DateTime CriadoEm { get; set; }

    public virtual Sala? Sala { get; set; }
    public virtual Usuario? Usuario { get; set; }
}