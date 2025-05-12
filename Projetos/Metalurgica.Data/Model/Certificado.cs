using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalurgica.Data.Model
{
    public class Certificado : BaseModel
    {
        [Key]
        public int Id_Certificado { get; set; }
        [ForeignKey("Lote")]
        public int Id_Lote { get; set; }
        public string Ds_NotaFiscal { get; set; }
        public string Ds_Cliente { get; set; }
        public decimal Vl_Peso { get; set; }
        public virtual Lote Lote { get; set; }
    }
}
