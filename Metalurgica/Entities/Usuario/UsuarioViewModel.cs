using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Usuario
{
    public class UsuarioViewModel
    {
        public int? IdTipoUsuario { get; set; }

        public string nome { get; set; } = null!;

        public string email { get; set; } = null!;
    }
}
