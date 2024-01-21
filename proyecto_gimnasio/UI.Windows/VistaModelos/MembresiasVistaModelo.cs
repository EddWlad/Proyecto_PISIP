using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Windows.VistaModelos
{
    public class MembresiasVistaModelo
    {
        public int IdMembresia { get; set; }
        public string Tipo { get; set; }
        public decimal Costo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> Fecha_inicio { get; set; }
        public Nullable<System.DateTime> Fecha_fin { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    }
}
