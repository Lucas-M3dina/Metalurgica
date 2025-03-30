namespace Metalurgica.Entities.Response
{
    public class ProdutoSelectResponse
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }

        public ProdutoSelectResponse()
        {
            
        }
        public ProdutoSelectResponse(int idProduto, string nomeProduto)
        {
            IdProduto = idProduto;
            Nome = nomeProduto;
        }
    }
}
