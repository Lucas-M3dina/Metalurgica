using Biz.Infra.Base;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Infra
{
    internal class LmEmpresa : BaseInfraContext<LmEmpresa>
    {
        public LmEmpresa(MetalurgicaEstudoContext ctx) : base(ctx)
        {
        }

        public LmEmpresa() : base(new MetalurgicaEstudoContext())
        {
        }
    }
}
