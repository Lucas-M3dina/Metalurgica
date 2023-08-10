using Biz.Infra.Base;
using Data.Context;
using Data.Models;

namespace Biz.Infra
{
    public class LmUsuarioInfra : BaseInfraContext<LmUsuario>
    {
        public LmUsuarioInfra(MetalurgicaEstudoContext ctx) : base(ctx) 
        { 
        }

        public LmUsuarioInfra() : base(new MetalurgicaEstudoContext())
        {
        }
    }
}
