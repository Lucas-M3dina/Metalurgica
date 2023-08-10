using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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

        public virtual TEntidade Adicionar(TEntidade entidade, string responsavel)
        {
            if (PropriedadeExiste(entidade, "FlAtivo") && PropriedadeExiste(entidade, "DtCadastro") && PropriedadeExiste(entidade, "DsUltAlteracao"))
            {
                ((dynamic)entidade).FlAtivo = true;
                ((dynamic)entidade).DtCadastro = DateTime.Now;
                ((dynamic)entidade).DsUltAlteracao = responsavel;

                _ctx.Set<TEntidade>().Attach(entidade);
                _ctx.Entry<TEntidade>((TEntidade)entidade).State = EntityState.Added;

                return entidade;
            }

            return new();
        }

        public virtual IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _ctx.Set<TEntidade>();

            if (!PropriedadeExiste(query, "FlAtivo"))
            {
                query = query.Where("FlAtivo != false").AsQueryable();
            }

            if (includeProperties.Any())
                return Include(_ctx.Set<TEntidade>(), includeProperties);

            return query;
        }

        public virtual TEntidade Editar(TEntidade entidade, string responsavel)
        {
            if (PropriedadeExiste(entidade, "FlAtivo") && PropriedadeExiste(entidade, "DtCadastro") && PropriedadeExiste(entidade, "DsUltAlteracao"))
            {
                _ctx.Entry<TEntidade>((TEntidade)entidade).Property("FlAtivo").IsModified = false;
                _ctx.Entry<TEntidade>((TEntidade)entidade).Property("DtCadastro").IsModified = false;

                ((dynamic)entidade).DtAlteracao = DateTime.Now;
                ((dynamic)entidade).DsUltAlteracao = responsavel;

                _ctx.Entry(entidade).State = EntityState.Modified;

                return entidade;
            }

            return new();
        }

        public virtual TEntidade Remover(int id, string responsavel)
        {
            TEntidade entidade = _ctx.Set<TEntidade>().Find(id);

            if (PropriedadeExiste(entidade, "FlAtivo") && PropriedadeExiste(entidade, "DtAlteracao") && PropriedadeExiste(entidade, "DsUltAlteracao"))
            {
                ((dynamic)entidade).FlAtivo = false;
                ((dynamic)entidade).DtAlteracao = DateTime.Now;
                ((dynamic)entidade).DsUltAlteracao = responsavel;

                _ctx.Entry<TEntidade>((TEntidade)entidade).State = EntityState.Modified;
            }

            return entidade ?? new();
        }


        public virtual TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
            => Listar(includeProperties).FirstOrDefault(where) ?? new();



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


        public virtual bool Commit() => _ctx.SaveChanges() > 0;
        public virtual void Dispose() => _ctx.Dispose();

    }
}
