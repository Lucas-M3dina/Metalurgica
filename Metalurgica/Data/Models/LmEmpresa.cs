using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class LmEmpresa
{
    public int IdEmpresa { get; set; }

    public int? IdLote { get; set; }

    public string? DsSegmento { get; set; }

    public string? NmNome { get; set; }

    public DateTime? DtCadastro { get; set; }

    public DateTime? DtAlteracao { get; set; }

    public bool? FlAtivo { get; set; }

    public string? DsUltAlteracao { get; set; }

    public virtual LmLote? IdLoteNavigation { get; set; }
}
