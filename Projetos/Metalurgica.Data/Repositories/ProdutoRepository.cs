using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;

namespace Metalurgica.Data.Repositories
{
    public class ProdutoRepository(MetalurgicaContext contexto) : BaseCRUD<Produto>(contexto), IProdutoRepository { }
}
