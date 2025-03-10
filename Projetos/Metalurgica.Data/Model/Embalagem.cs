using System.ComponentModel.DataAnnotations;

namespace Metalurgica.Data.Model
{
    public class Embalagem : BaseModel
    {
        [Key]
        public int Id_Embalagem { get; set; }
        public string Ds_Nome { get; set; }

        
        public virtual ICollection<ProdutoEmbalagem> ProdutoEmbalagens { get; set; } = new List<ProdutoEmbalagem>();
    }
}
