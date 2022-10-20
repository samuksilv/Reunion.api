using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reunion.api.Domain.Entities;

namespace Reunion.api.Infra.Database.EntityTypeConfigurations
{
    public class SalaConfiguration : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder
                .HasMany(x => x.Agendamentos)
                .WithOne(x => x.Sala)
                .HasForeignKey(x => x.SalaId);
        }
    }
}