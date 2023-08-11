using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class LmTipoUsuario
{
    public int IdTipoUsuario { get; set; }

    public string? NmTitulo { get; set; }

    public DateTime DtCadastro { get; set; }

    public DateTime? DtAlteracao { get; set; }

    public bool FlAtivo { get; set; }

    public string? DsUltAlteracao { get; set; }

    public virtual ICollection<LmUsuario> LmUsuarios { get; set; } = new List<LmUsuario>();
}
