using Metalurgica.Context;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace Biz.Infra.Base
{
    public abstract class BaseInfraContext<TEntidade> : IDisposable
    where TEntidade : class, new()
    {
        internal MetalurgicaEstudoContext _ctx;

        internal BaseInfraContext(MetalurgicaEstudoContext ctx)
        {
            this._ctx = ctx;
        }

        internal BaseInfraContext()
        {
            this._ctx = new MetalurgicaEstudoContext();
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
                query = query.Include(property);

            return query;
        }

        public virtual IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _ctx.Set<TEntidade>();

            if (!PropriedadeExiste(query, "Fl_Ativo"))
            {
                query = query.Where("Fl_Ativo != false").AsQueryable();
            }

            if (includeProperties.Any())
                return Include(_ctx.Set<TEntidade>(), includeProperties);

            return query;
        }

        private static bool PropriedadeExiste(IQueryable<TEntidade> entidades, string nomePropriedade)
        {
            foreach (var entidade in entidades)
            {
                if (!PropriedadeExiste(entidade, nomePropriedade))
                    return false;
            }

            return true;
        }


        private static bool PropriedadeExiste(TEntidade entidade, string nomePropriedade)
            => entidade.GetType().GetProperty(nomePropriedade) != null;


        public virtual void Dispose() => _ctx.Dispose();
    }
}
