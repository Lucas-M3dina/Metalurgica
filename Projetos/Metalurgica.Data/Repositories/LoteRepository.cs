using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;

namespace Metalurgica.Data.Repositories
{
    public class LoteRepository(MetalurgicaContext context) : BaseCRUD<Lote>(context), ILoteRepository
    {
    }
}
