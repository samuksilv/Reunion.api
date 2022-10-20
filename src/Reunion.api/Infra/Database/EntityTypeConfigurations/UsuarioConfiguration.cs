using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reunion.api.Domain.Entities;

namespace Reunion.api.Infra.Database.EntityTypeConfigurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder
                .HasMany(x => x.Agendamentos)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}