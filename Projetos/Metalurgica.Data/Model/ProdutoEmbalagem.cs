using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metalurgica.Data.Model
{
    public class ProdutoEmbalagem : BaseModel
    {
        [Key]
        public int Id_ProdutoEmbalagem { get; set; }

        [ForeignKey("Embalagem")]
        public int Id_Embalagem { get; set; }

        [ForeignKey("Produto")]
        public int Id_Produto { get; set; }
        public int Nr_Quantidade { get; set; }

        
        public virtual Produto Produto { get; set; }
        public virtual Embalagem Embalagem { get; set; }
    }
}
