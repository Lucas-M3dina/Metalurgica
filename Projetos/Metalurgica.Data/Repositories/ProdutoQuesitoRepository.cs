using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;

namespace Metalurgica.Data.Repositories
{
    public class ProdutoQuesitoRepository(MetalurgicaContext contexto) : BaseCRUD<ProdutoQuesito>(contexto), IProdutoQuesitoRepository { }
}
