using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class LmUsuario
{
    public int IdUsuario { get; set; }

    public int? IdTipoUsuario { get; set; }

    public string NmNome { get; set; } = null!;

    public string DsEmail { get; set; } = null!;

    public string DsSenha { get; set; } = null!;

    public DateTime DtCadastro { get; set; }

    public DateTime? DtAlteracao { get; set; }

    public bool FlAtivo { get; set; }

    public string? DsUltAlteracao { get; set; }

    public virtual LmTipoUsuario? IdTipoUsuarioNavigation { get; set; }
}
