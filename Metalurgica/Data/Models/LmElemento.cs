using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class LmElemento
{
    public int IdElemento { get; set; }

    public string? NmNome { get; set; }

    public string? DsEspecificacao { get; set; }

    public string? DsAstm { get; set; }

    public DateTime? DtCadastro { get; set; }

    public DateTime? DtAlteracao { get; set; }

    public bool? FlAtivo { get; set; }

    public string? DsUltAlteracao { get; set; }

    public virtual ICollection<LmProduto> LmProdutos { get; set; } = new List<LmProduto>();
}
