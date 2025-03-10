namespace Metalurgica.Entities.Response
{
    public class QuesitoResponse
    {
        public QuesitoResponse()
        {
            
        }
        public QuesitoResponse(int idQuesito, int codigo, string descricao)
        {
            IdQuesito = idQuesito;
            Codigo = codigo;
            Descricao = descricao;
        }

        public int IdQuesito { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
