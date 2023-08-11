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
    public class LmEmpresaInfra : BaseInfraContext<LmEmpresa>
    {
        public LmEmpresaInfra(MetalurgicaEstudoContext ctx) : base(ctx)
        {
        }

        public LmEmpresaInfra() : base(new MetalurgicaEstudoContext())
        {
        }
    }
}
