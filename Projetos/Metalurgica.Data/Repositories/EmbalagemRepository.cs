using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;

namespace Metalurgica.Data.Repositories
{
    public class EmbalagemRepository(MetalurgicaContext contexto) : BaseCRUD<Embalagem>(contexto), IEmbalagemRepository { }
}
