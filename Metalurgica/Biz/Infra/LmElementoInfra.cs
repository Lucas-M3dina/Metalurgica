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
    public class LmElementoInfra: BaseInfraContext<LmElemento>
    {
        public LmElementoInfra(MetalurgicaEstudoContext ctx) : base(ctx)
        {
        }

        public LmElementoInfra() : base(new MetalurgicaEstudoContext())
        {
        }
    }
}
