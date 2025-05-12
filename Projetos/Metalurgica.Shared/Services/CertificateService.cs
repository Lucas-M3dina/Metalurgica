using System.Net;
using Metalurgica.Data.Model;
using Metalurgica.Data.Repositories.Interfaces;
using Metalurgica.Entities.Common;
using Metalurgica.Entities.Enums;
using Metalurgica.Entities.Request;
using Metalurgica.Entities.Response;
using Metalurgica.Shared.Repositories;
using Metalurgica.Shared.Services.Interfaces;
using QuestPDF.Fluent;

namespace Metalurgica.Shared.Services
{
    public class CertificateService(
        IProdutoQuesitoRepository produtoQuesitoRepository,
        ILoteRepository loteRepository,
        ICertificadoRepository certificadoRepository
        ) : ICertificateService
    {
        private readonly IProdutoQuesitoRepository _produtoQuesitoRepository = produtoQuesitoRepository;
        private readonly ILoteRepository _loteRepository = loteRepository;
        private readonly ICertificadoRepository _certificadoRepository = certificadoRepository;


        public async Task<Retorno<IEnumerable<CertificatesListResponse>>> GetAllCertificates() { 
            var certificateDb = await _certificadoRepository.BuscarTodosAsync(x => x.Lote, x => x.Lote.Produto);
            var certificatesDto = certificateDb.Select(x => new CertificatesListResponse(
                idCertificado: x.Id_Certificado,
                nomeProduto: x.Lote.Produto.Ds_Nome,
                cliente: x.Ds_Cliente,
                notaFiscal: x.Ds_NotaFiscal,
                lote: x.Lote.Ds_Identificador
            ));

            return new Retorno<IEnumerable<CertificatesListResponse>>(true, certificatesDto, HttpStatusCode.OK);
        }

        public async Task<Retorno<object>> CreateCertificate(CertificateRequest request) {
            var certificateToCreate = new Certificado() { 
                Ds_NotaFiscal = request.NotaFiscal,
                Ds_Cliente = request.Cliente,
                Id_Lote = request.IdLote,
                Vl_Peso = request.Peso
            }; 

            await _certificadoRepository.CriarAsync( certificateToCreate );
            return new Retorno<object>(true, HttpStatusCode.OK);
        }

        public async Task<Retorno<CertificateDocumentResponse>> GenerateCertificate(int idCertificado)
        {
            var certificadoDb = await _certificadoRepository.BuscarPorAsync(x => x.Id_Certificado == idCertificado);
            var loteDb = await _loteRepository.BuscarPorAsync(x => x.Id_Lote == certificadoDb.Id_Lote, x => x.Produto);
            var quesitosDb = await _produtoQuesitoRepository.BuscarTodosPorAsync(x => x.Id_Produto == loteDb.Id_Produto, x => x.Quesito, x => x.Produto);

            var quesitosGrouped = quesitosDb
                .GroupBy(x => x.Quesito.Ds_TipoQuesito)
                .ToDictionary(
                    x => x.Key,
                    x => x.ToList()
                );

            var propriedadesFisicas = GetQuesitoDocument(quesitosGrouped, QuesitoTypesEnum.PropriedadesFisicas);
            var composicaoQuimica = GetQuesitoDocument(quesitosGrouped, QuesitoTypesEnum.ComposicaoQuimica);
            var granulometria = GetQuesitoDocument(quesitosGrouped, QuesitoTypesEnum.Granulometria);

            var certificateDto = new CertificateData(
                LogoPath: "",
                NumeroCertificado: certificadoDb.Id_Certificado.ToString(),
                Produto: loteDb.Produto.Ds_Nome,
                DataFabricacao: loteDb.Dt_Fabricacao?.ToString("dd/MM/yyyy"),
                DataValidade: loteDb.Dt_Validade?.ToString("dd/MM/yyyy"),
                DataEmissao: loteDb.Produto.Dt_Emissao?.ToString("dd/MM/yyyy"),
                Lote: loteDb.Ds_Identificador,
                Cliente: certificadoDb.Ds_Cliente,
                Peso: certificadoDb.Vl_Peso.ToString(),
                NotaFiscal: certificadoDb.Ds_NotaFiscal,
                PropriedadesFisicas: propriedadesFisicas,
                ComposicaoQuimica: composicaoQuimica,
                Granulometria: granulometria,
                Observacao: loteDb.Produto.Ds_Descricao,
                CondicoesEspeciais: "teste",
                AprovadoPor: "Leandro",
                Depto: "Qualidade"
            );

            var arquivoResponse = new CertificateDocumentResponse(
                arquivo: new CertificateDocument(certificateDto).GeneratePdf()
             ) ;

            return new Retorno<CertificateDocumentResponse>(true, arquivoResponse, System.Net.HttpStatusCode.OK);
        }

        private static List<QuesitoDocument> GetQuesitoDocument(Dictionary<string, List<Data.Model.ProdutoQuesito>> quesitosGrouped, QuesitoTypesEnum quesitoType)
        {
            var propriedadesDic = quesitosGrouped.GetValueOrDefault(quesitoType.GetDescription());
            if (propriedadesDic == null || propriedadesDic.Count == 0)
                return [];
            var propriedades = propriedadesDic.Select(x => new QuesitoDocument(
                Descricao: x.Quesito.Ds_Descricao,
                Unidade: x.Quesito.Ds_Unidade,
                Ensaio: x.Quesito.Ds_Metodo,
                Minimo: x.Vl_Minimo.ToString(),
                Resultado: x.Vl_Ideal.ToString()
            ));
            return propriedades.ToList();
        }
    }
}
