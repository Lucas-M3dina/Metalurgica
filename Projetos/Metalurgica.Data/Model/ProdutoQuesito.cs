using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metalurgica.Data.Model
{
    public class ProdutoQuesito : BaseModel
    {
        [Key]
        public int Id_ProdutoQuesito { get; set; }

        [ForeignKey("Quesito")]
        public int Id_Quesito { get; set; }

        [ForeignKey("Produto")]
        public int Id_Produto { get; set; }
        public decimal Vl_Ideal { get; set; }
        public decimal Vl_Minimo { get; set; }
        public decimal Vl_Maximo { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Quesito Quesito { get; set; }
    }
}
