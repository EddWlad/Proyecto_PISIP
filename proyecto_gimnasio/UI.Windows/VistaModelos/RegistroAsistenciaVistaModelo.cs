using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Windows.VistaModelos
{
    public class RegistroAsistenciaVistaModelo
    {
        public int Id_registro { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> Id_Cliente { get; set; }

    }
}
