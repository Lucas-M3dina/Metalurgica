using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metalurgica.Data.Model
{
    public class Lote : BaseModel
    {
        [Key]
        public int Id_Lote { get; set; }
        [ForeignKey("Produto")]
        public int Id_Produto { get; set; }
        public string Ds_Identificador { get; set; }
        public DateTime? Dt_Fabricacao { get; set; }
        public string Ds_Nome { get; set; }
        public string Ds_Validador { get; set; }
        public DateTime? Dt_Validade { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
