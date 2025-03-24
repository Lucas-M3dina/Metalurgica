using System;

namespace Metalurgica.Entities.Response
{
    public class LoteFilterResponse
    {
        public string NomeLote { get; set; }
        public DateTime? DataValidade { get; set; }
        public int NumeroLote { get; set; }
        public string NomeProduto { get; set; }
        public string Identificador { get; set; }
        public DateTime? DataFabricacao { get; set; }

        public LoteFilterResponse(string nomeLote, DateTime? dataValidade, int numeroLote, string nomeProduto, string identificador, DateTime? dataFabricacao)
        {
            NomeLote = nomeLote;
            DataValidade = dataValidade;
            NumeroLote = numeroLote;
            NomeProduto = nomeProduto;
            Identificador = identificador;
            DataFabricacao = dataFabricacao;
        }
    }
}
