namespace Metalurgica.Entities.Request
{
    public class EmbalagemRequest
    {

        public EmbalagemRequest()
        {
            
        }

        public EmbalagemRequest(int idEmbalagem)
        {
            IdEmbalagem = idEmbalagem;
        }

        public EmbalagemRequest(int idEmbalagem, int quantidade)
        {
            IdEmbalagem = idEmbalagem;
            Quantidade = quantidade;
        }

        public int IdEmbalagem { get; set; }
        public int Quantidade { get; set; }
    }
}
