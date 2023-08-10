using Biz.Infra.Base;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Infra
{
    internal class LmProduto : BaseInfraContext<LmProduto>
    {
        public LmProduto(MetalurgicaEstudoContext ctx) : base(ctx)
        {
        }

        public LmProduto() : base(new MetalurgicaEstudoContext())
        {
        }
    }
}
