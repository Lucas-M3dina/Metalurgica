using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class LmLote
{
    public int IdLote { get; set; }

    public int? IdProduto { get; set; }

    public int? IdEmbalagem { get; set; }

    public DateTime? DtCadastro { get; set; }

    public DateTime? DtAlteracao { get; set; }

    public bool? FlAtivo { get; set; }

    public string? DsUltAlteracao { get; set; }

    public virtual LmEmbalagem? IdEmbalagemNavigation { get; set; }

    public virtual LmProduto? IdProdutoNavigation { get; set; }

    public virtual ICollection<LmEmpresa> LmEmpresas { get; set; } = new List<LmEmpresa>();
}
