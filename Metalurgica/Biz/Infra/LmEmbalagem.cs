using Biz.Infra.Base;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz.Infra
{
    internal class LmEmbalagem : BaseInfraContext<LmEmbalagem>
    {
        public LmEmbalagem(MetalurgicaEstudoContext ctx) : base(ctx)
        {
        }

        public LmEmbalagem() : base(new MetalurgicaEstudoContext())
        {
        }
    }
}
