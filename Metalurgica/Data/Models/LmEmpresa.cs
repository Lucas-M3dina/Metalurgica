using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class LmEmpresa
{
    public int IdEmpresa { get; set; }

    public string DsSegmento { get; set; } = null!;

    public string NmNome { get; set; } = null!;

    public DateTime DtCadastro { get; set; }

    public DateTime? DtAlteracao { get; set; }

    public bool FlAtivo { get; set; }

    public string? DsUltAlteracao { get; set; }
}
