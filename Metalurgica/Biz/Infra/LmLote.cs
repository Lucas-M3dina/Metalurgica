using Biz.Infra.Base;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Infra
{
    internal class LmLote : BaseInfraContext<LmLote>
    {
        public LmLote(MetalurgicaEstudoContext ctx) : base(ctx)
        {
        }

        public LmLote() : base(new MetalurgicaEstudoContext())
        {
        }
    }
}
