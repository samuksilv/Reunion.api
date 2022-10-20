using Reunion.api.Domain.UseCases.Login;
using Reunion.api.Domain.UseCases.Usuario;

namespace Reunion.api.Infra.DI
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {

            // services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();            
            // services.AddScoped<ISalaRepository, SalaRepository>();


            // services.AddScoped<CancelarAgendamentoUseCase>();
            // services.AddScoped<CriarAgendamentoUseCase>();
            // services.AddScoped<EditarAgendamentoUseCase>();
            // services.AddScoped<ListarAgendamentosUseCase>();
            // services.AddScoped<ListarSalasUseCase>();


            services.AddScoped<EfetuarLoginUseCase>();
            services.AddScoped<CriarUsuarioUseCase>();
            services.AddScoped<AlterarUsuarioUseCase>();

            return services;
        }


    }
}