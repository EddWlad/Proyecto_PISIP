using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Windows.VistaModelos
{
    public class PromocionesVistaModelo
    {
        public int Id_promocion { get; set; }
        public Nullable<System.DateTime> Fecha_registro { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> Fecha_inicio { get; set; }
        public Nullable<System.DateTime> Fecha_fin { get; set; }
        public bool Estado { get; set; }
    }
}
