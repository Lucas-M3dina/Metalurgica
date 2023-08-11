using Biz.Infra.Base;
using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Infra
{
    public class LmProdutoInfra : BaseInfraContext<LmProduto>
    {
        public LmProdutoInfra(MetalurgicaEstudoContext ctx) : base(ctx)
        {
        }

        public LmProdutoInfra() : base(new MetalurgicaEstudoContext())
        {
        }
    }
}
