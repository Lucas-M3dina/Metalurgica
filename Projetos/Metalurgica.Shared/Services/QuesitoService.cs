using Metalurgica.Data.Repositories;
using Metalurgica.Data.Repositories.Interfaces;
using Metalurgica.Entities.Common;
using Metalurgica.Entities.Response;
using Metalurgica.Shared.Services.Interfaces;

namespace Metalurgica.Shared.Services
{
    public class QuesitoService(IQuesitoRepository quesitoRepository, IProdutoQuesitoRepository produtoQuesitoRepository) : IQuesitoService
    {
        private readonly IQuesitoRepository _quesitoRepository = quesitoRepository;
        private readonly IProdutoQuesitoRepository _produtoQuesitoRepository = produtoQuesitoRepository;

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
        
        public async Task<Retorno<IEnumerable<QuesitoDataResponse>>> ListAllQuesitosbyIdProduto(int idProduto)
        {
            var quesitosDb = await _produtoQuesitoRepository.BuscarTodosPorAsync(x => x.Id_Produto == idProduto, x=> x.Quesito);

            var quesitos = quesitosDb.Select(x => new QuesitoDataResponse(
                 nome: x.Quesito.Ds_Descricao,
                 ideal: x.Vl_Ideal,
                 minimo: x.Vl_Minimo,
                 maximo: x.Vl_Maximo 
            ));

            return new Retorno<IEnumerable<QuesitoDataResponse>>(true, quesitos, System.Net.HttpStatusCode.OK);
        }
    }
}
