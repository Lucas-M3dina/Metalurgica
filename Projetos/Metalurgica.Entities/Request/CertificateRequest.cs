namespace Metalurgica.Entities.Request
{
    public class CertificateRequest
    {
        public int IdLote { get; set; }
        public string NotaFiscal { get; set; }
        public string Cliente { get; set; }
        public decimal Peso { get; set; }
    }
}
