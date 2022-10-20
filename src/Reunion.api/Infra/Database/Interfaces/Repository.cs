

using Microsoft.EntityFrameworkCore;
using Reunion.api.Domain.Entities.Interfaces;

namespace Reunion.api.Infra.Database.Interfaces;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly AppDbContext _dbContext;

    public Repository(AppDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<TEntity> AlterarAsync(TEntity entidade)
    {
        _dbContext.Set<TEntity>().Update(entidade);

        return entidade;
    }

    public async Task<TEntity> InserirAsync(TEntity entidade)
    {
        await _dbContext.Set<TEntity>().AddAsync(entidade);

        return entidade;
    }

    public async Task RemoverAsync(Guid id)
    {
        TEntity entidade = await ObterPorIdAsync(id);
        _dbContext.Set<TEntity>().Remove(entidade);
    }

    public async Task<TEntity> ObterPorIdAsync(Guid id)
    {
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TEntity>> ObterTodosAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }


}