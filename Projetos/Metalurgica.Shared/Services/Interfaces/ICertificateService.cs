using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;

namespace Metalurgica.Shared.Services.Interfaces
{
    public interface ICertificateService
    {
        Task<Retorno<CertificateDocumentResponse>> GenerateCertificate(int idCertificado);
        Task<Retorno<IEnumerable<CertificatesListResponse>>> GetAllCertificates();
        Task<Retorno<object>> CreateCertificate(CertificateRequest request);
    }
}