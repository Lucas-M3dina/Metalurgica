using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;

namespace Metalurgica.Data.Repositories
{
    public class CertificadoRepository(MetalurgicaContext contexto) : BaseCRUD<Certificado>(contexto), ICertificadoRepository
    {
    }
}
