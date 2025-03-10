using Metalurgica.Data.Repositories.Interfaces;
using Metalurgica.Data.Repositories;
using Metalurgica.Entities.Response;
using Metalurgica.Entities.Common;
using Metalurgica.Shared.Services.Interfaces;

namespace Metalurgica.Shared.Services
{
    public class EmbalagemService(IEmbalagemRepository embalagemRepository) : IEmbalagemService
    {
        private readonly IEmbalagemRepository _embalagemRepository = embalagemRepository;

        public async Task<Retorno<IEnumerable<EmbalagemResponse>>> ListAllEmbalagens()
        {
            var embalagensDb = await _embalagemRepository.BuscarTodosAsync();

            var embalagens = embalagensDb.Select(x => new EmbalagemResponse(
                nome: x.Ds_Nome,
                idEmbalagem: x.Id_Embalagem
            ));

            return new Retorno<IEnumerable<EmbalagemResponse>>(true, embalagens, System.Net.HttpStatusCode.OK);
        }
    }
}
