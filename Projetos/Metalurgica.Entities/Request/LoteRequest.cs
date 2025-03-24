using System.ComponentModel.DataAnnotations.Schema;

namespace Metalurgica.Entities.Request
{
    public class LoteRequest
    {
        public int IdProduto { get; set; }
        public string Identificador { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public string Nome { get; set; }
        public string Validador { get; set; }
        public DateTime? DataValidade { get; set; }

    }
}
