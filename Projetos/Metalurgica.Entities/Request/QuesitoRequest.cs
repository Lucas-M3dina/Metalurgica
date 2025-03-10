namespace Metalurgica.Entities.Request
{
    public class QuesitoRequest
    {
        public QuesitoRequest()
        {
            
        }

        public QuesitoRequest(int idQuesito)
        {
            IdQuesito = idQuesito;
        }

        public QuesitoRequest(int idQuesito, decimal ideal, decimal minimo, decimal maximo)
        {
            IdQuesito = idQuesito;
            Ideal = ideal;
            Minimo = minimo;
            Maximo = maximo;
        }

        public int IdQuesito { get; set; }
        public decimal Ideal { get; set; }
        public decimal Minimo { get; set; }
        public decimal Maximo { get; set; }
    }
}
