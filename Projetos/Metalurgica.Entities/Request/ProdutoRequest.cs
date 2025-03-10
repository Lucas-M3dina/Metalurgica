namespace Metalurgica.Entities.Request
{
    public class ProdutoRequest
    {

        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Especificacao { get; set; }
        public DateTime? Emissao { get; set; }
        public int? Validade { get; set; }
        public int? Versao { get; set; }
        public string Io { get; set; }
        public string Setor { get; set; }
        public string Especie { get; set; }

        public List<EmbalagemRequest> Embalagens { get; set; } = [];
        public List<QuesitoRequest> Quesitos { get; set; } = [];
    }
}
