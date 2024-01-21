using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Windows.VistaModelos
{
    public class PagoDiarioVistaModelo
    {
        public int IdPagodiario { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    }
}
