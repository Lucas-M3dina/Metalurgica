using System.Linq.Expressions;

namespace Metalurgica.Data.Repositories.Interfaces
{
    public interface IBaseCRUD<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> BuscarTodosAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> CriarAsync(TEntity entity);
        Task<TEntity> AtualizarAsync(TEntity entity);
        Task DeletarAsync(int id);
        Task<IEnumerable<TEntity>> BuscarTodosPorAsync(Expression<Func<TEntity, bool>> condicao, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> BuscarPorAsync(Expression<Func<TEntity, bool>> condicao, params Expression<Func<TEntity, object>>[] includes);
    }
}
