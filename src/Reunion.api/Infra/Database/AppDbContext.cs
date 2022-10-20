

using Microsoft.EntityFrameworkCore;
using Reunion.api.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Reunion.api.Infra.Database.EntityTypeConfigurations;

public class AppDbContext : IdentityDbContext<Usuario, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Agendamento> Agendamento { get; set; }
    public virtual DbSet<Sala> Sala { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UsuarioConfiguration());
        builder.ApplyConfiguration(new AgendamentoConfiguration());
        builder.ApplyConfiguration(new SalaConfiguration());

    }
}
