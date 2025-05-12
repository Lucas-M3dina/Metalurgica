using System.ComponentModel.DataAnnotations;

namespace Metalurgica.Data.Model
{
    public class Quesito : BaseModel
    {
        [Key]
        public int Id_Quesito { get; set; }
        public int Nr_Codigo { get; set; }
        public string Ds_Descricao { get; set; }
        public string Ds_Metodo { get; set; }
        public string Ds_Unidade { get; set; }
        public string Ds_TipoQuesito { get; set; }


        public virtual ICollection<ProdutoQuesito> ProdutoQuesitos { get; set; } = new List<ProdutoQuesito>();
    }
}
