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
    public class LmEmbalagemInfra : BaseInfraContext<LmEmbalagem>
    {
        public LmEmbalagemInfra(MetalurgicaEstudoContext ctx) : base(ctx)
        {
        }

        public LmEmbalagemInfra() : base(new MetalurgicaEstudoContext())
        {
        }
    }
}
