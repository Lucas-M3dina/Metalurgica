using Biz.Infra.Base;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Infra
{
    internal class LmElemento: BaseInfraContext<LmElemento>
    {
        public LmElemento(MetalurgicaEstudoContext ctx) : base(ctx)
        {
        }

        public LmElemento() : base(new MetalurgicaEstudoContext())
        {
        }
    }
}
