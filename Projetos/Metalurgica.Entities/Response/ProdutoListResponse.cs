namespace Metalurgica.Entities.Response
{
    public class ProdutoListResponse
    {
        public ProdutoListResponse()
        {
            
        }

        public ProdutoListResponse(string nome, string editor, DateTime dataCriacao, string setor)
        {
            Nome = nome;
            Editor = editor;
            DataCriacao = dataCriacao;
            Setor = setor;
        }

        public string Nome { get; set; }
        public string Editor { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Setor { get; set; }

    }
}
