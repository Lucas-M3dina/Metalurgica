using System.ComponentModel.DataAnnotations;

namespace Metalurgica.Data.Model
{
    public class Cargo : BaseModel
    {
        [Key]
        public int Id_Cargo { get; set; }
        public string Ds_Cargo { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
