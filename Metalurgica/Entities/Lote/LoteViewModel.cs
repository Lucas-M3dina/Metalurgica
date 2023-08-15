using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Lote
{
    public class LoteViewModel
    {
        public int? IdProduto { get; set; }

        public int? IdEmbalagem { get; set; }

        public int? IdEmpresa { get; set; }

        public string? NmMetodologiaAnaliseGranumetrica { get; set; }

        public string? DsObservacoes { get; set; }

    }
}
