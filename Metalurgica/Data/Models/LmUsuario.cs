using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class LmUsuario
{
    public int IdUsuario { get; set; }

    public int? IdTipoUsuario { get; set; }

    public string? NmNome { get; set; }

    public string? DsEmail { get; set; }

    public string? DsSenha { get; set; }

    public DateTime? DtCadastro { get; set; }

    public DateTime? DtAlteracao { get; set; }

    public bool? FlAtivo { get; set; }

    public string? DsUltAlteracao { get; set; }

    public virtual LmTipoUsuario? IdTipoUsuarioNavigation { get; set; }
}
