using Metalurgica.Data.Model;

namespace Metalurgica.Entities.Common
{
    public record QuesitoDocument(string Descricao, string Unidade, string Ensaio, string Minimo, string Resultado);

    public record CertificateData(
        string LogoPath,
        string NumeroCertificado,
        string Produto,
        string DataFabricacao,
        string DataValidade,
        string DataEmissao,
        string Lote,
        string Cliente,
        string Peso,
        string NotaFiscal,
        List<QuesitoDocument> PropriedadesFisicas,
        List<QuesitoDocument> ComposicaoQuimica,
        List<QuesitoDocument> Granulometria,
        string Observacao,
        string CondicoesEspeciais,
        string AprovadoPor,
        string Depto
    );
}
