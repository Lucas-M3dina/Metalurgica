namespace Metalurgica.Entities.Response
{
    public class CertificatesListResponse
    {
        public CertificatesListResponse(int idCertificado, string nomeProduto, string cliente, string notaFiscal, string lote)
        {
            IdCertificado = idCertificado;
            NomeProduto = nomeProduto;
            Cliente = cliente;
            NotaFiscal = notaFiscal;
            Lote = lote;
        }

        public int IdCertificado { get; set; }
        public string NomeProduto { get; set; }
        public string Cliente { get; set; }
        public string NotaFiscal { get; set; }
        public string Lote { get; set; }


    }
}
