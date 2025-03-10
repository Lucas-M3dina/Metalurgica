using Metalurgica.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Metalurgica.Data.Repositories
{
    public class BaseCRUD<TEntity> : IBaseCRUD<TEntity>
        where TEntity : class
    {
        protected readonly MetalurgicaContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseCRUD(MetalurgicaContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> BuscarTodosAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            query = MontarConsulta(includes, query);

            return await query.ToListAsync();
        }

        public async Task<TEntity> CriarAsync(TEntity entity)
        {

            PropertyInfo? dataCriacaoProperty = entity.GetType().GetProperty("Dt_Criacao");
            PropertyInfo? flAtivoProperty = entity.GetType().GetProperty("Fl_Ativo");
            if (dataCriacaoProperty == null || flAtivoProperty == null) return null;

            flAtivoProperty.SetValue(entity, true);
            dataCriacaoProperty.SetValue(entity, DateTime.Now);

            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> AtualizarAsync(TEntity entity)
        {
            PropertyInfo? dataAtualizacao = entity.GetType().GetProperty("Dt_Alteracao");
            if (dataAtualizacao == null) return null;

            dataAtualizacao.SetValue(entity, DateTime.Now);

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeletarAsync(int id)
        {
            var entity = await BuscarPorIdAsync(id);
            if (entity == null) return;

            PropertyInfo? property = entity.GetType().GetProperty("Fl_Ativo");
            property?.SetValue(entity, false);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> BuscarTodosPorAsync(Expression<Func<TEntity, bool>> condicao, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            query = MontarConsulta(includes, query);

            return await query.Where(condicao).ToListAsync();
        }

        public async Task<TEntity> BuscarPorAsync(Expression<Func<TEntity, bool>> condicao, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            query = MontarConsulta(includes, query);

            return await query.FirstOrDefaultAsync(condicao);
        }

        private async Task<TEntity> BuscarPorIdAsync(int id)
        {
            var keyName = _context.Model.FindEntityType(typeof(TEntity))
                                .FindPrimaryKey()
                                .Properties
                                .Select(p => p.Name)
                                .Single();

            return await _dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, keyName) == id && EF.Property<bool>(e, "Fl_Ativo") == true);

        }

        private static IQueryable<TEntity> MontarConsulta(Expression<Func<TEntity, object>>[] includes, IQueryable<TEntity> query)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            query = query.Where(e => EF.Property<bool>(e, "Fl_Ativo") == true);
            return query;
        }
    }
}
