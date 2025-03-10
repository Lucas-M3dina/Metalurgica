using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;

namespace Metalurgica.Data.Repositories
{
    public class QuesitoRepository(MetalurgicaContext contexto) : BaseCRUD<Quesito>(contexto), IQuesitoRepository { }
}
