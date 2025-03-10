using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metalurgica.Data.Model
{
    public class Usuario : BaseModel
    {
        [Key]
        public int Id_Usuario { get; set; }

        [ForeignKey("Cargo")]
        public int Id_Cargo { get; set; }              
        public string Ds_Nome { get; set; }            
        public string Ds_Senha { get; set; }           
        public string Ds_Email { get; set; }

        public Cargo Cargo { get; set; }
    }
}
