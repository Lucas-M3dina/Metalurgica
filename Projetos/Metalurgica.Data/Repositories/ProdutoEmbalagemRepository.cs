using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;

namespace Metalurgica.Data.Repositories
{
    public class ProdutoEmbalagemRepository(MetalurgicaContext contexto) : BaseCRUD<ProdutoEmbalagem>(contexto), IProdutoEmbalagemRepository { }
}
