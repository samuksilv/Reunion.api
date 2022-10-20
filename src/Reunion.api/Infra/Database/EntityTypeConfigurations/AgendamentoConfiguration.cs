using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reunion.api.Domain.Entities;

namespace Reunion.api.Infra.Database.EntityTypeConfigurations
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder
               .HasOne(x => x.Usuario)
               .WithMany(x => x.Agendamentos)
               .HasForeignKey(x => x.UsuarioId);

            builder
                .HasOne(x => x.Sala)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.SalaId);
        }
    }
}