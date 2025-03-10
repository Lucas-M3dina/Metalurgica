using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;

namespace Metalurgica.Data.Repositories
{
    public class CargoRepository(MetalurgicaContext contexto) : BaseCRUD<Cargo>(contexto), ICargoRepository
    {
    }
}
