using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories;
using System.Net;
using Metalurgica.Data.Repositories.Interfaces;
using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Shared.Services.Interfaces;
using Metalurgica.Entities.Response;
using System.Globalization;

namespace Metalurgica.Shared.Services
{
    public class LoteService(ILoteRepository loteRepository) : ILoteService
    {
        public async Task<Retorno<object>> CreateLote(LoteRequest lote)
        {
            var loteDb = new Lote()
            {
                Id_Produto = lote.IdProduto,
                Ds_Identificador = lote.Identificador,
                Dt_Fabricacao = lote.DataFabricacao,
                Ds_Nome = lote.Nome,
                Ds_Validador = "Não identificado", // TODO: Pegar essa info do token JWT
                Dt_Validade = lote.DataValidade
            };

            await loteRepository.CriarAsync(loteDb);

            return new Retorno<object>(true, HttpStatusCode.Created);
        }

        public async Task<Retorno<IEnumerable<LoteSelectResponse>>> ListLotesToSelect()
        {
            var lotesDb = await loteRepository.BuscarTodosAsync();
            var selectLotes = lotesDb.Select(x => new LoteSelectResponse(x.Id_Lote, x.Ds_Identificador));
            return new Retorno<IEnumerable<LoteSelectResponse>>(true, selectLotes, HttpStatusCode.OK);
        }
        
        public async Task<Retorno<IEnumerable<LoteFilterResponse>>> ListLotesByFilter(string search)
        {
            DateTime? searchDate = null;
            if (DateTime.TryParseExact(search, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
            {
                searchDate = dt;
            }

            IEnumerable<Lote> lotesDb = await loteRepository.BuscarTodosPorAsync(x => 
                string.IsNullOrEmpty(search)
                || x.Ds_Nome.Contains(search)
                || (searchDate.HasValue && x.Dt_Validade.HasValue && x.Dt_Validade.Value.Date == searchDate.Value.Date)
                || x.Id_Lote.ToString().Contains(search)
                || x.Produto.Ds_Nome.Contains(search),
                x => x.Produto
            );

            var lotesResponse = lotesDb
                .OrderByDescending(x => x.Dt_Criacao)
                .Select(x => new LoteFilterResponse(
                    nomeLote: x.Ds_Nome, 
                    dataValidade: x.Dt_Validade, 
                    numeroLote: x.Id_Lote,
                    nomeProduto: x.Produto.Ds_Nome, 
                    identificador: x.Ds_Identificador, 
                    dataFabricacao: x.Dt_Fabricacao
                ));

            return new Retorno<IEnumerable<LoteFilterResponse>>(true, lotesResponse, HttpStatusCode.OK);
        }
    }
}
