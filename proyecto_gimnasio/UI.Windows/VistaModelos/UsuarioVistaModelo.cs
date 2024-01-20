using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Windows.VistaModelos
{
    public class UsuarioVistaModelo
    {
        public int id_usuario { get; set; }
        public string email { get; set; }
        public string nombre_usuario { get; set; }
        public string contraseña { get; set; }
        public Nullable<bool> estado { get; set; }
    }
}
