using Reunion.api.Domain.Entities.Interfaces;

namespace Reunion.api.Infra.Database.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> InserirAsync(TEntity entidade);
    Task<TEntity> AlterarAsync(TEntity entidade);
    Task RemoverAsync(Guid id);
    Task<TEntity> ObterPorIdAsync(Guid id);
    Task<List<TEntity>> ObterTodosAsync();
}