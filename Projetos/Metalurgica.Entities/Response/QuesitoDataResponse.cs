namespace Metalurgica.Entities.Response
{
    public class QuesitoDataResponse
    {
        public QuesitoDataResponse()
        {

        }

        public QuesitoDataResponse(string nome, decimal ideal, decimal minimo, decimal maximo)
        {
            Nome = nome;
            Ideal = ideal;
            Minimo = minimo;
            Maximo = maximo;
        }

        public string Nome { get; set; }
        public decimal Ideal { get; set; }
        public decimal Minimo { get; set; }
        public decimal Maximo { get; set; }

    }
}
