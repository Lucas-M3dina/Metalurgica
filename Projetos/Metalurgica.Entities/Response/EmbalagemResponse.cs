namespace Metalurgica.Entities.Response
{
    public class EmbalagemResponse
    {
        public EmbalagemResponse()
        {
            
        }

        public EmbalagemResponse(int idEmbalagem, string nome)
        {
            IdEmbalagem = idEmbalagem;
            Nome = nome;
        }

        public int IdEmbalagem { get; set; }
        public string Nome { get; set; }
    }
}
