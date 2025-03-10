using System.ComponentModel.DataAnnotations;

namespace Metalurgica.Data.Model
{
    public class Produto : BaseModel
    {
        public Produto()
        {
            
        }


        [Key]
        public int Id_Produto { get; set; }
        public string Ds_Nome { get; set; }
        public string Ds_Descricao { get; set; }
        public string Ds_Especificacao { get; set; }
        public DateTime? Dt_Emissao { get; set; }
        public int? Nr_Validade { get; set; }
        public int? Nr_Versao { get; set; }
        public string Ds_Io { get; set; }
        public string Ds_Setor { get; set; }
        public string Ds_Especie { get; set; }


        public virtual ICollection<ProdutoEmbalagem> ProdutoEmbalagens { get; set; } = new List<ProdutoEmbalagem>();
        public virtual ICollection<ProdutoQuesito> ProdutoQuesitos { get; set; } = new List<ProdutoQuesito>();
    }
}
