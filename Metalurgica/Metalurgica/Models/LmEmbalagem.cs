using System;
using System.Collections.Generic;

namespace Metalurgica.Models;

public partial class LmEmbalagem
{
    public int IdEmbalagem { get; set; }

    public string NmNome { get; set; } = null!;

    public DateTime? DtCadastro { get; set; }

    public DateTime? DtAlteracao { get; set; }

    public bool? FlAtivo { get; set; }

    public string? DsUltAlteracao { get; set; }

    public virtual ICollection<LmLote> LmLotes { get; set; } = new List<LmLote>();
}
