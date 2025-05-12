namespace Metalurgica.Entities.Response
{
    public class CertificateDocumentResponse
    {
        public CertificateDocumentResponse(byte[] arquivo)
        {
            Arquivo = arquivo;
        }

        public byte[] Arquivo { get; set; }
        public string Filename { get; set; } = "certificado.pdf";
        public string Type { get; set; } = "application/pdf";
    }
}
