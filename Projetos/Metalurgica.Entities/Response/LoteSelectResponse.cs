namespace Metalurgica.Entities.Response
{
    public class LoteSelectResponse
    {
        public LoteSelectResponse(int idLote, string identificadorLote)
        {
            IdLote = idLote;
            IdentificadorLote = identificadorLote;
        }

        public int IdLote { get; set; }
        public string IdentificadorLote { get; set; }

    }
}
