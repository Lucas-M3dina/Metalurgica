using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories;
using System.Net;
using Metalurgica.Data.Repositories.Interfaces;
using Metalurgica.Entities.Common;
using Metalurgica.Entities.Request;
using Metalurgica.Shared.Services.Interfaces;

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
                Ds_Validador = lote.Validador,
                Dt_Validade = lote.DataValidade
            };

            await loteRepository.CriarAsync(loteDb);

            return new Retorno<object>(true, HttpStatusCode.Created);
        }
    }
}
