using Metalurgica.Data.Repositories.Interfaces;
using Metalurgica.Entities.Common;
using Metalurgica.Entities.Response;
using Metalurgica.Shared.Services.Interfaces;

namespace Metalurgica.Shared.Services
{
    public class QuesitoService(IQuesitoRepository quesitoRepository) : IQuesitoService
    {
        private readonly IQuesitoRepository _quesitoRepository = quesitoRepository;

        public async Task<Retorno<IEnumerable<QuesitoResponse>>> ListAllQuesitos()
        {
            var quesitosDb = await _quesitoRepository.BuscarTodosAsync();

            var quesitos = quesitosDb.Select(x => new QuesitoResponse(
                idQuesito: x.Id_Quesito,
                codigo: x.Nr_Codigo,
                descricao: x.Ds_Descricao
            ));

            return new Retorno<IEnumerable<QuesitoResponse>>(true, quesitos, System.Net.HttpStatusCode.OK);
        }
    }
}
