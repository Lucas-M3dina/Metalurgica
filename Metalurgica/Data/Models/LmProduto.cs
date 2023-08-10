using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class LmProduto
{
    public int IdProduto { get; set; }

    public int? IdElemento { get; set; }

    public string NmNome { get; set; } = null!;

    public DateTime? DtCadastro { get; set; }

    public DateTime? DtAlteracao { get; set; }

    public bool? FlAtivo { get; set; }

    public string? DsUltAlteracao { get; set; }

    public virtual LmElemento? IdElementoNavigation { get; set; }

    public virtual ICollection<LmLote> LmLotes { get; set; } = new List<LmLote>();
}
